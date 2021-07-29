using System.Collections.Generic;

namespace apr.WebMVC.Models
{
    public class ResponseResult<T>
    {
        private bool _state;
        public bool State
        {
            get
            {
                return (Items != null || Item != null) || _state;
            }
            set
            {
                _state = value;
            }
        }
        public string Message { get; set; }
        public T Item { get; set; }
        public List<T> Items { get; set; }
    }
}