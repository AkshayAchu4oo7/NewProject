//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Answer
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }
        public Nullable<int> QuestionID { get; set; }
    
        public virtual Question Question { get; set; }
    }
}
