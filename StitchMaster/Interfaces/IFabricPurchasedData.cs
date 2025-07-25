﻿using StitchMaster.BusinessLogic;

namespace StitchMaster.Interfaces
{
    public interface IFabricPurchasedData
    {
        public bool StoreObject(Customer customer,FabricPurchased fabricPurchased);
        public bool DeleteObject(FabricPurchased fabricPurchased);
        public bool UpdateObject(FabricPurchased fabricPurchased);
        public List<FabricPurchased> GetAllObjects();
        public int StoreFabricPurchased(FabricPurchased fabricPurchasedData, int tailorid);
        public List<FabricPurchased> GetPurchasedFabricsByInHoldStatus(Customer customer, bool inHold);
        public FabricPurchased GetFabricPurchasedByID(int ID);
        public List<FabricPurchased> GetFabricPurchasedByStore(FabricStore fabricStore);
    }
}
