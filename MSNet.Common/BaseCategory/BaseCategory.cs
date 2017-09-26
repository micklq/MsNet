using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;

namespace MSNet.Common
{
    /// <summary>
    /// Permission
    /// </summary>
    public class BaseCategory<TId> : EntityBase<TId>    
    {
        #region Instance Properties         
        public string Name { get; set; } 
        public string Description { get; set; } 
        public long ParentId { get; set; }  

        #endregion           
      
    }
}

