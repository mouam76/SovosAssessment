using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SovosAssessmentMVC.Models
{
    public static class Enum
    {
        public enum TypeEnum
        {
            DataImport = 1, StateReport = 2, AuditReport = 3
        }

        public enum StatusEnum
        {
            Processing = 1, Complete = 2, Failed = 3
        }
    }
}