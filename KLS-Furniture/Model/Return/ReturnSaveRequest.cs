using System;
using System.Collections.Generic;

namespace KLS_Furniture.Model.Return
{
    /// <summary>
    /// Represents the data needed to save one return transaction.
    /// </summary>
    public class ReturnSaveRequest
    {
        public int EmployeeId { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public List<ReturnItemInput> Items { get; set; } = new List<ReturnItemInput>();
    }
}