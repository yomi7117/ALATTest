﻿
using System;
using System.Collections.Generic;

using System.Text;

namespace ALATTest.Utility.ExceptionUtility
{
    public class ResponseErrorMessageUtility
    {
        public const string NotExistProtectedId = "Operation Failed. The {0} supplied is not valid or does not exist.";
        public const string NotExistRecord = "Operation Failed. The {0} provided does not exist on the system.";
        public const string NotValidProtectedId = "Operation Failed. The {0} supplied is not valid.";
        public const string NotFoundMerchantUser = "Your merchant record cannot be found.";
        public const string PermissionCheck = "This is record is system generated records(s). You do not have the permission to edit this record. Only User-defined record(s) can be edited";
        public const string NoFilterProvided = "Operation Failed. No filter options selected.";
        public const string RecordNumberNotTally = "The number of record on the system does not match the number sent to the system";
        public const string ActiveEncounterExist = "The patient already has an active encounter on the system";
        /// <summary>
        /// {0} - Record Column Name
        /// </summary>
        public const string RecordExistBefore = "The {0} record you are trying to create already exists on the system.";
        public const string RecordExistBeforeDeactivated = "The {0} record you are trying to create already exists but deactivated on the system. Contact your administrator.";
        public const string RecordAttachedToOthers = "The {0} record you are trying to delete has an attached {1} on the system.";
        public const string NotAuthorizedUser = "Your request cannot be processed. Please Login to Continue";
        public const string RecordNotFound = "The record does not exist";
        public const string OperationFailed = "The operation was not successful.";
        public const string PatientInSessionForVital = "The Patient Is Probably In Session For Vitals";
        public const string ValueNotMatch = "The {0} does not match {1}";

        /// <summary>
        /// {0} - Record Column Name
        /// {1} - Incoming Record Taken
        /// </summary>
        public const string TakenRecord = "{0} : {1} is already taken";
        public const string SelectRecord = "Please select {0} from the dropdown list";
        public const string CannotCreateMoreThanOneRecord = "You cannot create more than one record on this system";
        public const string RecordNotSaved = "Operation Failed. We encountered an error saving your data on the system";
        public const string PasswordNotMatch = "Password and Confirm Password do not match";
        public const string RecordNotFetched = "Operation Failed. We encountered an error fetching your data on the system";
        public const string LoginUsernamePasswordNotEmpy = "Username or Password cannot be empty";
        public const string InvalidLoginAttempt = "Invalid login attempt";
        public const string LockedOutUser = "User account locked out.";
        public const string StatusBool = "Status can only be true or false";
        public const string MappingRecordCannotBeEmpty = "Operation Failed. {0} or Associated {1} cannot be empty";
        public const string InvalidToken = "Invalid token";
        public const string InvalidUser = "Invalid user";
        public const string CannotContainPassword = "Your password cannot contain element of {0}";
        public const string EmptyFormFile = "FormFile is Empty.";
        public const string SupportedFileFormat = "The system currently supports only {0} format.";
        public const string RequiredColumnsFromTemplate = "Operation Failed. Ensure that the column arrangement conforms to the provided template";
        public const string DuplicateRecordFromFile = "There are duplicate records in the file uploaded as follows \n {0}";
        public const string PlanBenefitOperationFailed = "Operation Failed. Unable to {0} associated services to the plan coverage";
        public const string BenefitCoveredAlreadyPlan = "The Service Type benefit you are trying to create is already covered by the plan.";
        public const string BenefitCoveredAlreadyPlanDeactivated = "The Service Type benefit you are trying to create is already covered by the plan but deactivated.";
        public const string GroupMappingRemoveOperationFailed = "Operation Failed. Unable to Remove associated {0} from group.";
        public const string SMSProviderRecordCreation = "Operation Failed. Records have been created for all available SMS Provider.";
        public const string InvalidRecordFormat = "{0} Value Supplied is not in correct format.";
        public const string ServiceMappingAborted = "Mapping Aborted. There exists Sub-Service Type(s) under this Service Type.";
        public const string SubServiceCreationAborted = "Subservice Creation Aborted. There exists Service(s) under the Service Type.";
        public const string Successful = "Successful.";
      
    }
}
