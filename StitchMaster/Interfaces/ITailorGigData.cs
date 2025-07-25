﻿using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface ITailorGigData
    {
        public bool StoreObject(Tailor tailor,TailorGig tailorGig);
        public bool DeleteObject(TailorGig tailorGig);
        public bool UpdateObject(TailorGig tailorGig);
        public List<TailorGig> GetAllObjects();
        public List<TailorGig> GetAllTailorGigs(Tailor tailor);
        public TailorGig? GetGigById(int gigId);
        public int GetGigOwner(int gigId);
        public Tailor GetGigTailor(int gigId);
    }
}
