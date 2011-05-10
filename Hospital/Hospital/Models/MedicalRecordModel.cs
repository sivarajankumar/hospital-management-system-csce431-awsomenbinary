using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MySql.Data.MySqlClient;
using Hospital.Providers;

namespace Hospital.Models
{
    #region models
    public class MedicalRecord
    {
        public previousMedicalHistory prevMedHistory { get; set; }
        public String currentMedicalHistory { get; set; }
        public List<String> prescriptions { get; set; }

        public class previousMedicalHistory
        {
            public String operations { get; set; }
            public String allergies { get; set; }
            public String ongoingMedication { get; set; }
            public String pastDoctor { get; set; }
            public String familyHistory { get; set; }
            public String emergencyContactName { get; set; }
            public String emergencyContactNumber { get; set; }
            public String recentTests { get; set; }
            public String lastestBloodPressure { get; set; }
            public String other { get; set; }
        }

        public class prescription
        {
            public String rxName { get; set; }
            public bool filled { get; set; }
        }
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

        public void updateMedicalecordsForPatient(String patient, MedicalRecord newRecords)
        {
            _provider.updateMedicalRecordsForPatient(patient, newRecords);
        }
    }
    #endregion

}