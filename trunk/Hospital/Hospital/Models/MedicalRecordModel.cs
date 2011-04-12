using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital.Providers;

namespace Hospital.Models
{
    #region models
    public class MedicalRecord
    {
        public String previousMedicalHistory { get; set; }
        public String currentMedicalHistory { get; set; }
        public List<String> prescriptions {get; set;}
    }
    #endregion

    #region services
    public class MedicalRecordService
    {
        private readonly RecordsProvider _provider;

        public MedicalRecordService() : this(null)
        {
        }

        public MedicalRecordService(RecordsProvider provider)
        {
            _provider = provider ?? new RecordsProvider();
        }

        public MedicalRecord getMedicalRecordsForPatient(int id)
        {
            return _provider.getMedicalRecordsForPatient(id);
        }

        public MedicalRecord getMedicalRecordsForPatient(String name)
        {
            return _provider.getMedicalRecordsForPatient(name);
        }
    }
    #endregion
}