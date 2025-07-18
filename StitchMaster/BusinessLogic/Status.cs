﻿using StitchMaster.HelperClasses;

namespace StitchMaster.BusinessLogic
{
    public class Status
    {
        private readonly int _statusID;
        private string _statusValue;

        #region Getter Setter Start --------------------------------------------
        public int StatusID
        {
            get { return _statusID; }

        }
        public string StatusValue
        {
            get { return _statusValue; }
            set { _statusValue = value; }
        }
        #endregion Getter Setter Start --------------------------------------------

        #region Constructors Start ----------------------------------------------
        public Status(int statusID, string statusValue)
        {
            if (IsValid.DBID(statusID))
            {
                this._statusID = statusID;
            }
            else
            {
                throw new InvalidOperationException("Invalid Status ID");
            }
            this.StatusValue = statusValue;
        }

        public Status(string statusValue)
        {
            this.StatusValue = statusValue;
        }
        public Status(Status s)
        {
            if (IsValid.DBID(s.StatusID))
            {
                this._statusID = s.StatusID;
            }
            else
            {
                throw new InvalidOperationException("Invalid Status ID");
            }
            this.StatusValue = s.StatusValue;
        }
        #endregion Constructors Start ----------------------------------------------
    }
}
