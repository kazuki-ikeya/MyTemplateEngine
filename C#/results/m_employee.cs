
using System;

namespace entities
{
    
    /// <summary>
    /// m_employee
    /// </summary>
    public partial class MEmployee
    {

        [JsonProperty("employee_code")]
        public string EmployeeCode { get; set; }

        [JsonProperty("employee_name")]
        public string EmployeeName { get; set; }

        [JsonProperty("employee_name_kana")]
        public string EmployeeNameKana { get; set; }

        [JsonProperty("is_deleted")]
        public boolean IsDeleted { get; set; }

        [JsonProperty("register_datetime")]
        public datetime RegisterDatetime { get; set; }

        [JsonProperty("register_pg_name")]
        public string RegisterPgName { get; set; }

        [JsonProperty("register_employee_code")]
        public string RegisterEmployeeCode { get; set; }

        [JsonProperty("update_datetime")]
        public datetime UpdateDatetime { get; set; }

        [JsonProperty("update_pg_name")]
        public string UpdatePgName { get; set; }

        [JsonProperty("update_employee_code")]
        public string UpdateEmployeeCode { get; set; }

    }
}