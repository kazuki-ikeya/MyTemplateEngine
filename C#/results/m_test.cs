
using System;

namespace entities
{
    
    /// <summary>
    /// m_test
    /// </summary>
    public partial class MTest
    {

        [JsonProperty("test_key")]
        public string TestKey { get; set; }

        [JsonProperty("test_number")]
        public integer TestNumber { get; set; }

        [JsonProperty("test_name")]
        public string TestName { get; set; }

        [JsonProperty("test_date")]
        public DATE TestDate { get; set; }

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