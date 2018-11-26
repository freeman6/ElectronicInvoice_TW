﻿using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Infrastructure.Helper;
using ElectronicInvoice.Produce.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Produce
{
    public class InvoiceDetailApi : ApiBase<InvoiceDetailModel>
    {
        protected override string SetParamter(InvoiceDetailModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();

            paramter["version"] = "0.3";
            paramter["type"] = model.Type.ToString();
            paramter["invNum"] = model.InvNum;
            paramter["action"] = "qryInvDetail";
            paramter["generation"] = "V2";
            paramter["invTerm"] = model.InvTerm;
            paramter["invDate"] = model.InvDate.ToString("yyyy/MM/dd");
            paramter["encrypt"] = model.Encrypt;
            paramter["sellerID"] = model.SellerID;
            paramter["randomNumber"] = model.RandomNumber; 
            paramter["UUID"] = paramterContext.UUID;
            paramter["appID"] = paramterContext.GovAppId;

            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }
}