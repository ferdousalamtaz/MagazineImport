using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineImport.Code.Mapping
{
    public abstract class MagazineMapperDefaults : IMagazineMapper
    {
        public abstract string ImportJobId { get; }

        public virtual int Id { get { return 0; } set { } }
        public virtual string ExternalId { get { return string.Empty; } }
        public virtual string Issn { get { return string.Empty; } }
        public virtual string ProductName { get { return string.Empty; } }
        public virtual string Description { get { return string.Empty; } }
        public virtual string FirstIssue { get { return string.Empty; } }
        public virtual string IssueImageUrl { get { return string.Empty; } }
        public virtual DateTime? IssueDate { get { return null; } }
        public virtual int IssueNr { get { return 0; } }
        public virtual int FreqPerYear { get { return 1; } }
        public virtual string CountryName { get { return string.Empty; } }
        public virtual string Language { get { return string.Empty; } }

        public virtual string ExternalOfferId { get { return string.Empty; } }
        public virtual string OfferId { get { return string.Empty; } }
        public virtual string CampaignId { get { return string.Empty; } }
        public virtual string GiveId { get { return string.Empty; } }
        public virtual string SpecialId { get { return string.Empty; } }
        public virtual string XmasOfferId { get { return string.Empty; } }
        public virtual string XmasCampaignId { get { return string.Empty; } }
        public virtual string OfferIdPrepaid { get { return string.Empty; } }
        public virtual string CampaignIdPrepaid { get { return string.Empty; } }
        public virtual string GiveIdPrepaid { get { return string.Empty; } }
        public virtual string SpecialIdPrepaid { get { return string.Empty; } }
        public virtual string XmasOfferIdPrepaid { get { return string.Empty; } }
        public virtual string XmasCampaignIdPrepaid { get { return string.Empty; } }
        public virtual int SubscriptionLength { get { return 1; } }
        public virtual decimal InPrice { get { return 0; } }
        public virtual decimal Price { get { return 0; } }
        public virtual int CurrencyId { get { return 1; } }
        public virtual int CountryId { get { return 1; } }
        public virtual string ExtraInfo { get { return string.Empty; } }
        public virtual int Stock { get { return 0; } }
        public virtual int Vat { get { return 0; } }

    }

}
