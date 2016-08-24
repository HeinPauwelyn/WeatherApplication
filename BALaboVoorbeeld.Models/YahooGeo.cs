using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALaboVoorbeeld.Models
{
    public class Url
    {
        //        public string __invalid_name__execution-start-time { get; set; }
        //    public string __invalid_name__execution-stop-time { get; set; }
        //public string __invalid_name__execution-time { get; set; }
        public string Content { get; set; }
    }

    public class Diagnostics
    {
        public string PubliclyCallable { get; set; }
        public Url Url { get; set; }
        //    public string __invalid_name__user-time { get; set; }
        //public string __invalid_name__service-time { get; set; }
        //    public string __invalid_name__build-version { get; set; }
    }

    public class GeoResult
    {
        public string Quality { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Offsetlat { get; set; }
        public string Offsetlon { get; set; }
        public string Radius { get; set; }
        public string SingleLineAddress { get; set; }
        public object Name { get; set; }
        public object Line1 { get; set; }
        public string Line2 { get; set; }
        public object Line3 { get; set; }
        public string Line4 { get; set; }
        public object House { get; set; }
        public object Street { get; set; }
        public object XStreet { get; set; }
        public object Unittype { get; set; }
        public object Unit { get; set; }
        public object Postal { get; set; }
        public object Neighborhood { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        //public string Country { get; set; }
        public string Countrycode { get; set; }
        public string Statecode { get; set; }
        //public string countycode { get; set; }
        public string Uzip { get; set; }
        public object Hash { get; set; }
        public string WoeID { get; set; }
        public string WoeType { get; set; }
    }

    public class GeoResults
    {
        public GeoResult Result { get; set; }
    }

    public class GeoQuery
    {
        public int Count { get; set; }
        public string Created { get; set; }
        public string Lang { get; set; }
        public Diagnostics Diagnostics { get; set; }
        public GeoResults Results { get; set; }
    }

    public class YahooGeo
    {
        public GeoQuery Query { get; set; }
    }
}
