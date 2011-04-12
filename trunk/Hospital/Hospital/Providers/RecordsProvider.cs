using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration.Provider;
using System.Configuration;
using Hospital.Models;

namespace Hospital.Providers
{
    public sealed class RecordsProvider : BaseProvider
    {

        public MedicalRecord getMedicalRecordsForPatient(String name)
        {
            return getMedicalRecordsForPatient(getUserIdFromName(name));
        }

        public MedicalRecord getMedicalRecordsForPatient(int id)
        {
            MedicalRecord record = new MedicalRecord();
            if (id > 0)
            {
                //#TODO get medical records
                record.currentMedicalHistory = "Sudden Adult Death Syndrome";
                record.previousMedicalHistory = "Death, taxes.";
                record.prescriptions = new List<string>();
                record.prescriptions.Add("Lots and lots of cocaine.");
            }

            return record;
        }

    }
}