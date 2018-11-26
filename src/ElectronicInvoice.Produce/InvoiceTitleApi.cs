﻿using System;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Mapping;
using System.Collections.Generic;
using ElectronicInvoice.Produce.Infrastructure.Helper;

namespace ElectronicInvoice.Produce
{
    public class InvoiceTitleApi : ApiBase<InvoiceTitleModel>
    {
        protected override string SetParamter(InvoiceTitleModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();
            paramter["version"] = "0.3";
            paramter["type"] = model.Type.ToString();
            paramter["invNum"] = model.InvNum;
            paramter["action"] = "qryInvHeader";
            paramter["generation"] = "V2";
            paramter["invDate"] = model.InvDate.ToString("yyyy/MM/dd");
            paramter["UUID"] = paramterContext.UUID;
            paramter["appID"] = paramterContext.GovAppId;

            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }
}