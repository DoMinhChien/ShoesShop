﻿using ShoesShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesShop.BLL.Interfaces
{
    public interface ISupplierBLL
    {
        List<tblSupplier> GetSupplierForMasterData();
    }
}
