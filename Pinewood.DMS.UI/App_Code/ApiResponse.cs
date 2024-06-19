using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ApiResponse
/// </summary>
public class ApiResponse
{  
        public bool Success { get; set; } = true;
        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
        public object Result { get; set; }
   
}