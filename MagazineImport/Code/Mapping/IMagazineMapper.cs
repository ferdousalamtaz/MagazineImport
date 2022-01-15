using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineImport.Code.Mapping
{
    public interface IMagazineMapper
    {
        int Id { get; set; }

        string ImportJobId { get; }
        string ExternalId { get; }

        string Issn { get; }
        string ProductName { get; }
        string Description { get; }
        string FirstIssue { get; } 

        string IssueImageUrl { get; }
        DateTime? IssueDate { get; }
        int IssueNr { get; }

        int FreqPerYear { get; }
        string CountryName { get; }
        string Language { get; }

        string ExternalOfferId { get; }
        string OfferId { get; }
        string CampaignId { get; }
        string GiveId { get; }
        string SpecialId { get; }
        string XmasOfferId { get; }
        string XmasCampaignId { get; }
        string OfferIdPrepaid { get; }
        string CampaignIdPrepaid { get; }
        string GiveIdPrepaid { get; }
        string SpecialIdPrepaid { get; }
        string XmasOfferIdPrepaid { get; }
        string XmasCampaignIdPrepaid { get; } 

        int SubscriptionLength { get; } 
        decimal InPrice { get; }
        decimal Price { get; }
        int CurrencyId { get; }
        int CountryId { get; }
        string ExtraInfo { get; } 
        int Stock { get; }
        int Vat { get; }

    }

    }
