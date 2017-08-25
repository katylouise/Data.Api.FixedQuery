﻿namespace Parliament.Data.Api.FixedQuery.Controllers
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Http;
    using VDS.RDF;
    using VDS.RDF.Query;

    public partial class FixedQueryController
    {

        [HttpGet]
        public Graph person_by_id_mock(string person_id)
        {
            var triples = @"
<http://id.ukpds.org/THE_PERSON> <http://id.ukpds.org/schema/personHasFormalBodyMembership> <http://id.ukpds.org/JCORBTRADECOMMITTEEMEMBERSHIP> .
<http://id.ukpds.org/JCORBTRADECOMMITTEEMEMBERSHIP> <http://id.ukpds.org/schema/formalBodyMembershipHasFormalBody> <http://id.ukpds.org/TRADECOMMITTEE> .
<http://id.ukpds.org/JCORBTRADECOMMITTEEMEMBERSHIP> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/FormalBodyMembership> .
<http://id.ukpds.org/JCORBTRADECOMMITTEEMEMBERSHIP> <http://id.ukpds.org/schema/formalBodyMembershipStartDate> ""1991-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/JCORBTRADECOMMITTEEMEMBERSHIP> <http://id.ukpds.org/schema/formalBodyMembershipEndDate> ""2001-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/TRADECOMMITTEE> <http://id.ukpds.org/schema/formalBodyName> ""Trade Committee"" .
<http://id.ukpds.org/TRADECOMMITTEE> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/FormalBody> .

<http://id.ukpds.org/THE_PERSON> <http://id.ukpds.org/schema/memberHasExOfficioMembership> <http://id.ukpds.org/JCORBJOBSCOMMITTEEMEMBERSHIP> .
<http://id.ukpds.org/JCORBJOBSCOMMITTEEMEMBERSHIP> <http://id.ukpds.org/schema/formalBodyMembershipHasFormalBody> <http://id.ukpds.org/TRADECOMMITTEE> .
<http://id.ukpds.org/JCORBJOBSCOMMITTEEMEMBERSHIP> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/FormalBodyMembership> .
<http://id.ukpds.org/JCORBJOBSCOMMITTEEMEMBERSHIP> <http://id.ukpds.org/schema/formalBodyMembershipStartDate> ""1998-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/JCORBJOBSCOMMITTEEMEMBERSHIP> <http://id.ukpds.org/schema/formalBodyMembershipEndDate> ""2012-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/JOBSCOMMITTEE> <http://id.ukpds.org/schema/formalBodyName> ""Jobs Committee"" .
<http://id.ukpds.org/JOBSCOMMITTEE> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/FormalBody> .
".Replace("THE_PERSON",person_id);

            var graph = new Graph();
            graph.LoadFromString(triples);
            var calledGraph = new FixedQueryController().person_by_id(person_id);
            calledGraph.Merge(graph);
            return calledGraph;
        }
        [HttpGet]
        public Graph committee_by_id(string committee_id)
        {
            var triples = @"
<http://id.ukpds.org/TRADECOMMITTEE> <http://id.ukpds.org/schema/formalBodyName> ""Trade Committee"" .
<http://id.ukpds.org/TRADECOMMITTEE> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/FormalBody> .
<http://id.ukpds.org/TRADECOMMITTEE> <http://id.ukpds.org/schema/formalBodyHasFormalBodyMembership> <http://id.ukpds.org/JCORBTRADECOMMITTEEMEMBERSHIP> .
<http://id.ukpds.org/JCORBTRADECOMMITTEEMEMBERSHIP> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/FormalBodyMembership> .
<http://id.ukpds.org/JCORBTRADECOMMITTEEMEMBERSHIP> <http://id.ukpds.org/schema/formalBodyMembershipStartDate> ""1991-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/JCORBTRADECOMMITTEEMEMBERSHIP> <http://id.ukpds.org/schema/formalBodyMembershipEndDate> ""2001-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/personHasformalBodyMembership> <http://id.ukpds.org/JCORBTRADECOMMITTEEMEMBERSHIP> .
<http://id.ukpds.org/tJxPOiSd> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/Person> .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/personGivenName> ""Jeremy"" .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/personFamilyName> ""Corbyn"" .
<http://id.ukpds.org/tJxPOiSd> <http://example.com/F31CBD81AD8343898B49DC65743F0BDF> ""Jeremy Corbyn"" .
<http://id.ukpds.org/tJxPOiSd> <http://example.com/D79B0BAC513C4A9A87C9D5AFF1FC632F> ""Rt Hon Jeremy Corbyn MP"" .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/memberHasMemberImage> <http://id.ukpds.org/u0mXpY2m> .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/personOtherNames> ""Bernard"" .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/partyMemberHasPartyMembership> <http://id.ukpds.org/xiOjcfHS> .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/kGCr7yVH> .
<http://id.ukpds.org/u0mXpY2m> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/MemberImage> .
<http://id.ukpds.org/TuDsm6mf> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/ConstituencyGroup> .
<http://id.ukpds.org/TuDsm6mf> <http://id.ukpds.org/schema/constituencyGroupName> ""Islington North"" .
<http://id.ukpds.org/TuDsm6mf> <http://id.ukpds.org/schema/constituencyGroupStartDate> ""1983-06-09""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/TuDsm6mf> <http://id.ukpds.org/schema/constituencyGroupEndDate> ""1997-05-01""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/kGCr7yVH> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/kGCr7yVH> <http://id.ukpds.org/schema/incumbencyEndDate> ""1987-06-11""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/kGCr7yVH> <http://id.ukpds.org/schema/incumbencyStartDate> ""1983-06-09""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/kGCr7yVH> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/mH68Wbzd> .
<http://id.ukpds.org/mH68Wbzd> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/HouseSeat> .
<http://id.ukpds.org/mH68Wbzd> <http://id.ukpds.org/schema/houseSeatHasConstituencyGroup> <http://id.ukpds.org/TuDsm6mf> .
<http://id.ukpds.org/mH68Wbzd> <http://id.ukpds.org/schema/houseSeatHasHouse> <http://id.ukpds.org/Kz7ncmrt> .
<http://id.ukpds.org/891w1b1k> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/Party> .
<http://id.ukpds.org/891w1b1k> <http://id.ukpds.org/schema/partyName> ""Labour"" .
<http://id.ukpds.org/xiOjcfHS> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/PartyMembership> .
<http://id.ukpds.org/xiOjcfHS> <http://id.ukpds.org/schema/partyMembershipStartDate> ""1983-06-09""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/xiOjcfHS> <http://id.ukpds.org/schema/partyMembershipEndDate> ""2015-03-30""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/xiOjcfHS> <http://id.ukpds.org/schema/partyMembershipHasParty> <http://id.ukpds.org/891w1b1k> .
<http://id.ukpds.org/Kz7ncmrt> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/House> .
<http://id.ukpds.org/Kz7ncmrt> <http://id.ukpds.org/schema/houseName> ""House of Commons"" .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/partyMemberHasPartyMembership> <http://id.ukpds.org/whVj0EG6> .
<http://id.ukpds.org/whVj0EG6> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/PartyMembership> .
<http://id.ukpds.org/whVj0EG6> <http://id.ukpds.org/schema/partyMembershipStartDate> ""2015-05-07""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/whVj0EG6> <http://id.ukpds.org/schema/partyMembershipEndDate> ""2017-05-03""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/whVj0EG6> <http://id.ukpds.org/schema/partyMembershipHasParty> <http://id.ukpds.org/891w1b1k> .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/partyMemberHasPartyMembership> <http://id.ukpds.org/uLNi5UkB> .
<http://id.ukpds.org/uLNi5UkB> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/PartyMembership> .
<http://id.ukpds.org/uLNi5UkB> <http://id.ukpds.org/schema/partyMembershipStartDate> ""2017-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/uLNi5UkB> <http://id.ukpds.org/schema/partyMembershipHasParty> <http://id.ukpds.org/891w1b1k> .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/TVu8LFst> .
<http://id.ukpds.org/TVu8LFst> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/TVu8LFst> <http://id.ukpds.org/schema/incumbencyEndDate> ""1992-04-09""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/TVu8LFst> <http://id.ukpds.org/schema/incumbencyStartDate> ""1987-06-11""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/TVu8LFst> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/mH68Wbzd> .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/cPGNU6ZH> .
<http://id.ukpds.org/cPGNU6ZH> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/cPGNU6ZH> <http://id.ukpds.org/schema/incumbencyEndDate> ""1997-05-01""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/cPGNU6ZH> <http://id.ukpds.org/schema/incumbencyStartDate> ""1992-04-09""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/cPGNU6ZH> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/mH68Wbzd> .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/iA1cHCIH> .
<http://id.ukpds.org/1HnT8xin> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/ConstituencyGroup> .
<http://id.ukpds.org/1HnT8xin> <http://id.ukpds.org/schema/constituencyGroupName> ""Islington North"" .
<http://id.ukpds.org/1HnT8xin> <http://id.ukpds.org/schema/constituencyGroupStartDate> ""1997-05-01""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/1HnT8xin> <http://id.ukpds.org/schema/constituencyGroupEndDate> ""2010-05-06""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/iA1cHCIH> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/iA1cHCIH> <http://id.ukpds.org/schema/incumbencyEndDate> ""2001-06-07""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/iA1cHCIH> <http://id.ukpds.org/schema/incumbencyStartDate> ""1997-05-01""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/iA1cHCIH> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/B3nuidv4> .
<http://id.ukpds.org/B3nuidv4> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/HouseSeat> .
<http://id.ukpds.org/B3nuidv4> <http://id.ukpds.org/schema/houseSeatHasConstituencyGroup> <http://id.ukpds.org/1HnT8xin> .
<http://id.ukpds.org/B3nuidv4> <http://id.ukpds.org/schema/houseSeatHasHouse> <http://id.ukpds.org/Kz7ncmrt> .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/kHn3mOQI> .
<http://id.ukpds.org/kHn3mOQI> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/kHn3mOQI> <http://id.ukpds.org/schema/incumbencyEndDate> ""2005-05-05""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/kHn3mOQI> <http://id.ukpds.org/schema/incumbencyStartDate> ""2001-06-07""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/kHn3mOQI> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/B3nuidv4> .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/P88Ubpa2> .
<http://id.ukpds.org/P88Ubpa2> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/P88Ubpa2> <http://id.ukpds.org/schema/incumbencyEndDate> ""2010-05-06""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/P88Ubpa2> <http://id.ukpds.org/schema/incumbencyStartDate> ""2005-05-05""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/P88Ubpa2> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/B3nuidv4> .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/FbNu8cEu> .
<http://id.ukpds.org/06ZfKsSW> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/ConstituencyGroup> .
<http://id.ukpds.org/06ZfKsSW> <http://id.ukpds.org/schema/constituencyGroupName> ""Islington North"" .
<http://id.ukpds.org/06ZfKsSW> <http://id.ukpds.org/schema/constituencyGroupStartDate> ""2010-05-06""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/FbNu8cEu> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/FbNu8cEu> <http://id.ukpds.org/schema/incumbencyEndDate> ""2015-03-30""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/FbNu8cEu> <http://id.ukpds.org/schema/incumbencyStartDate> ""2010-05-06""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/FbNu8cEu> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/VKUYDXoa> .
<http://id.ukpds.org/VKUYDXoa> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/HouseSeat> .
<http://id.ukpds.org/VKUYDXoa> <http://id.ukpds.org/schema/houseSeatHasConstituencyGroup> <http://id.ukpds.org/06ZfKsSW> .
<http://id.ukpds.org/VKUYDXoa> <http://id.ukpds.org/schema/houseSeatHasHouse> <http://id.ukpds.org/Kz7ncmrt> .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/tXVTiEYq> .
<http://id.ukpds.org/tXVTiEYq> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/tXVTiEYq> <http://id.ukpds.org/schema/incumbencyEndDate> ""2017-05-03""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/tXVTiEYq> <http://id.ukpds.org/schema/incumbencyStartDate> ""2015-05-07""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/tXVTiEYq> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/VKUYDXoa> .
<http://id.ukpds.org/tJxPOiSd> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/yKbi7ikQ> .
<http://id.ukpds.org/FeCebO0j> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/ContactPoint> .
<http://id.ukpds.org/FeCebO0j> <http://id.ukpds.org/schema/email> ""leader@labour.org.uk"" .
<http://id.ukpds.org/FeCebO0j> <http://id.ukpds.org/schema/phoneNumber> ""020 7219 3545"" .
<http://id.ukpds.org/FeCebO0j> <http://id.ukpds.org/schema/contactPointHasPostalAddress> <http://id.ukpds.org/hytooZR3> .
<http://id.ukpds.org/hytooZR3> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/PostalAddress> .
<http://id.ukpds.org/hytooZR3> <http://id.ukpds.org/schema/addressLine1> ""House of Commons"" .
<http://id.ukpds.org/hytooZR3> <http://id.ukpds.org/schema/addressLine2> ""London"" .
<http://id.ukpds.org/hytooZR3> <http://id.ukpds.org/schema/postCode> ""SW1A 0AA"" .
<http://id.ukpds.org/yKbi7ikQ> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/yKbi7ikQ> <http://id.ukpds.org/schema/incumbencyStartDate> ""2017-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/yKbi7ikQ> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/VKUYDXoa> .
<http://id.ukpds.org/yKbi7ikQ> <http://id.ukpds.org/schema/incumbencyHasContactPoint> <http://id.ukpds.org/FeCebO0j> .

<http://id.ukpds.org/TRADECOMMITTEE> <http://id.ukpds.org/schema/formalBodyHasFormalBodyMembership> <http://id.ukpds.org/BBORBTRADECOMMITTEEMEMBERSHIP> .
<http://id.ukpds.org/BBORBTRADECOMMITTEEMEMBERSHIP> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/FormalBodyMembership> .
<http://id.ukpds.org/BBORBTRADECOMMITTEEMEMBERSHIP> <http://id.ukpds.org/schema/formalBodyMembershipStartDate> ""1995-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/BBORBTRADECOMMITTEEMEMBERSHIP> <http://id.ukpds.org/schema/formalBodyMembershipEndDate> ""2005-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasAlternateMembership> <http://id.ukpds.org/BBORBTRADECOMMITTEEMEMBERSHIP> .
<http://id.ukpds.org/BEREMY> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/Person> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/personGivenName> ""Beremy"" .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/personFamilyName> ""Borbyn"" .
<http://id.ukpds.org/BEREMY> <http://example.com/F31CBD81AD8343898B49DC65743F0BDF> ""Beremy Borbyn"" .
<http://id.ukpds.org/BEREMY> <http://example.com/D79B0BAC513C4A9A87C9D5AFF1FC632F> ""Rt Hon Beremy Borbyn MP"" .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasMemberImage> <http://id.ukpds.org/u0mXpY2m> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/personOtherNames> ""Bernard"" .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/partyMemberHasPartyMembership> <http://id.ukpds.org/xiOjcfHS> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/kGCr7yVH> .
<http://id.ukpds.org/u0mXpY2m> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/MemberImage> .
<http://id.ukpds.org/TuDsm6mf> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/ConstituencyGroup> .
<http://id.ukpds.org/TuDsm6mf> <http://id.ukpds.org/schema/constituencyGroupName> ""Islington North"" .
<http://id.ukpds.org/TuDsm6mf> <http://id.ukpds.org/schema/constituencyGroupStartDate> ""1983-06-09""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/TuDsm6mf> <http://id.ukpds.org/schema/constituencyGroupEndDate> ""1997-05-01""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/kGCr7yVH> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/kGCr7yVH> <http://id.ukpds.org/schema/incumbencyEndDate> ""1987-06-11""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/kGCr7yVH> <http://id.ukpds.org/schema/incumbencyStartDate> ""1983-06-09""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/kGCr7yVH> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/mH68Wbzd> .
<http://id.ukpds.org/mH68Wbzd> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/HouseSeat> .
<http://id.ukpds.org/mH68Wbzd> <http://id.ukpds.org/schema/houseSeatHasConstituencyGroup> <http://id.ukpds.org/TuDsm6mf> .
<http://id.ukpds.org/mH68Wbzd> <http://id.ukpds.org/schema/houseSeatHasHouse> <http://id.ukpds.org/Kz7ncmrt> .
<http://id.ukpds.org/891w1b1k> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/Party> .
<http://id.ukpds.org/891w1b1k> <http://id.ukpds.org/schema/partyName> ""Labour"" .
<http://id.ukpds.org/xiOjcfHS> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/PartyMembership> .
<http://id.ukpds.org/xiOjcfHS> <http://id.ukpds.org/schema/partyMembershipStartDate> ""1983-06-09""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/xiOjcfHS> <http://id.ukpds.org/schema/partyMembershipEndDate> ""2015-03-30""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/xiOjcfHS> <http://id.ukpds.org/schema/partyMembershipHasParty> <http://id.ukpds.org/891w1b1k> .
<http://id.ukpds.org/Kz7ncmrt> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/House> .
<http://id.ukpds.org/Kz7ncmrt> <http://id.ukpds.org/schema/houseName> ""House of Commons"" .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/partyMemberHasPartyMembership> <http://id.ukpds.org/whVj0EG6> .
<http://id.ukpds.org/whVj0EG6> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/PartyMembership> .
<http://id.ukpds.org/whVj0EG6> <http://id.ukpds.org/schema/partyMembershipStartDate> ""2015-05-07""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/whVj0EG6> <http://id.ukpds.org/schema/partyMembershipEndDate> ""2017-05-03""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/whVj0EG6> <http://id.ukpds.org/schema/partyMembershipHasParty> <http://id.ukpds.org/891w1b1k> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/partyMemberHasPartyMembership> <http://id.ukpds.org/uLNi5UkB> .
<http://id.ukpds.org/uLNi5UkB> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/PartyMembership> .
<http://id.ukpds.org/uLNi5UkB> <http://id.ukpds.org/schema/partyMembershipStartDate> ""2017-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/uLNi5UkB> <http://id.ukpds.org/schema/partyMembershipHasParty> <http://id.ukpds.org/891w1b1k> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/TVu8LFst> .
<http://id.ukpds.org/TVu8LFst> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/TVu8LFst> <http://id.ukpds.org/schema/incumbencyEndDate> ""1992-04-09""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/TVu8LFst> <http://id.ukpds.org/schema/incumbencyStartDate> ""1987-06-11""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/TVu8LFst> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/mH68Wbzd> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/cPGNU6ZH> .
<http://id.ukpds.org/cPGNU6ZH> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/cPGNU6ZH> <http://id.ukpds.org/schema/incumbencyEndDate> ""1997-05-01""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/cPGNU6ZH> <http://id.ukpds.org/schema/incumbencyStartDate> ""1992-04-09""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/cPGNU6ZH> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/mH68Wbzd> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/iA1cHCIH> .
<http://id.ukpds.org/1HnT8xin> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/ConstituencyGroup> .
<http://id.ukpds.org/1HnT8xin> <http://id.ukpds.org/schema/constituencyGroupName> ""Islington North"" .
<http://id.ukpds.org/1HnT8xin> <http://id.ukpds.org/schema/constituencyGroupStartDate> ""1997-05-01""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/1HnT8xin> <http://id.ukpds.org/schema/constituencyGroupEndDate> ""2010-05-06""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/iA1cHCIH> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/iA1cHCIH> <http://id.ukpds.org/schema/incumbencyEndDate> ""2001-06-07""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/iA1cHCIH> <http://id.ukpds.org/schema/incumbencyStartDate> ""1997-05-01""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/iA1cHCIH> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/B3nuidv4> .
<http://id.ukpds.org/B3nuidv4> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/HouseSeat> .
<http://id.ukpds.org/B3nuidv4> <http://id.ukpds.org/schema/houseSeatHasConstituencyGroup> <http://id.ukpds.org/1HnT8xin> .
<http://id.ukpds.org/B3nuidv4> <http://id.ukpds.org/schema/houseSeatHasHouse> <http://id.ukpds.org/Kz7ncmrt> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/kHn3mOQI> .
<http://id.ukpds.org/kHn3mOQI> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/kHn3mOQI> <http://id.ukpds.org/schema/incumbencyEndDate> ""2005-05-05""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/kHn3mOQI> <http://id.ukpds.org/schema/incumbencyStartDate> ""2001-06-07""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/kHn3mOQI> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/B3nuidv4> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/P88Ubpa2> .
<http://id.ukpds.org/P88Ubpa2> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/P88Ubpa2> <http://id.ukpds.org/schema/incumbencyEndDate> ""2010-05-06""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/P88Ubpa2> <http://id.ukpds.org/schema/incumbencyStartDate> ""2005-05-05""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/P88Ubpa2> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/B3nuidv4> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/FbNu8cEu> .
<http://id.ukpds.org/06ZfKsSW> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/ConstituencyGroup> .
<http://id.ukpds.org/06ZfKsSW> <http://id.ukpds.org/schema/constituencyGroupName> ""Islington North"" .
<http://id.ukpds.org/06ZfKsSW> <http://id.ukpds.org/schema/constituencyGroupStartDate> ""2010-05-06""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/FbNu8cEu> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/FbNu8cEu> <http://id.ukpds.org/schema/incumbencyEndDate> ""2015-03-30""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/FbNu8cEu> <http://id.ukpds.org/schema/incumbencyStartDate> ""2010-05-06""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/FbNu8cEu> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/VKUYDXoa> .
<http://id.ukpds.org/VKUYDXoa> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/HouseSeat> .
<http://id.ukpds.org/VKUYDXoa> <http://id.ukpds.org/schema/houseSeatHasConstituencyGroup> <http://id.ukpds.org/06ZfKsSW> .
<http://id.ukpds.org/VKUYDXoa> <http://id.ukpds.org/schema/houseSeatHasHouse> <http://id.ukpds.org/Kz7ncmrt> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/tXVTiEYq> .
<http://id.ukpds.org/tXVTiEYq> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/tXVTiEYq> <http://id.ukpds.org/schema/incumbencyEndDate> ""2017-05-03""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/tXVTiEYq> <http://id.ukpds.org/schema/incumbencyStartDate> ""2015-05-07""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/tXVTiEYq> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/VKUYDXoa> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/yKbi7ikQ> .
<http://id.ukpds.org/FeCebO0j> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/ContactPoint> .
<http://id.ukpds.org/FeCebO0j> <http://id.ukpds.org/schema/email> ""leader@labour.org.uk"" .
<http://id.ukpds.org/FeCebO0j> <http://id.ukpds.org/schema/phoneNumber> ""020 7219 3545"" .
<http://id.ukpds.org/FeCebO0j> <http://id.ukpds.org/schema/contactPointHasPostalAddress> <http://id.ukpds.org/hytooZR3> .
<http://id.ukpds.org/hytooZR3> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/PostalAddress> .
<http://id.ukpds.org/hytooZR3> <http://id.ukpds.org/schema/addressLine1> ""House of Commons"" .
<http://id.ukpds.org/hytooZR3> <http://id.ukpds.org/schema/addressLine2> ""London"" .
<http://id.ukpds.org/hytooZR3> <http://id.ukpds.org/schema/postCode> ""SW1A 0AA"" .
<http://id.ukpds.org/yKbi7ikQ> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/yKbi7ikQ> <http://id.ukpds.org/schema/incumbencyStartDate> ""2017-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/yKbi7ikQ> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/VKUYDXoa> .
<http://id.ukpds.org/yKbi7ikQ> <http://id.ukpds.org/schema/incumbencyHasContactPoint> <http://id.ukpds.org/FeCebO0j> .

<http://id.ukpds.org/TRADECOMMITTEE> <http://id.ukpds.org/schema/formalBodyHasFormalBodyMembership> <http://id.ukpds.org/DDORBTRADECOMMITTEEMEMBERSHIP> .
<http://id.ukpds.org/DDORBTRADECOMMITTEEMEMBERSHIP> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/FormalBodyMembership> .
<http://id.ukpds.org/DDORBTRADECOMMITTEEMEMBERSHIP> <http://id.ukpds.org/schema/formalBodyMembershipStartDate> ""2000-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/DDORBTRADECOMMITTEEMEMBERSHIP> <http://id.ukpds.org/schema/formalBodyMembershipEndDate> ""2020-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/DEREMY> <http://id.ukpds.org/schema/memberHasExOfficioMembership> <http://id.ukpds.org/DDORBTRADECOMMITTEEMEMBERSHIP> .
<http://id.ukpds.org/DEREMY> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/Person> .
<http://id.ukpds.org/DEREMY> <http://id.ukpds.org/schema/personGivenName> ""Deremy"" .
<http://id.ukpds.org/DEREMY> <http://id.ukpds.org/schema/personFamilyName> ""Dorbyn"" .
<http://id.ukpds.org/DEREMY> <http://example.com/F31CBD81AD8343898B49DC65743F0BDF> ""Deremy Dorbyn"" .
<http://id.ukpds.org/DEREMY> <http://example.com/D79B0BAC513C4A9A87C9D5AFF1FC632F> ""Rt Hon Deremy Dorbyn MP"" .
<http://id.ukpds.org/DEREMY> <http://id.ukpds.org/schema/memberHasMemberImage> <http://id.ukpds.org/u0mXpY2m> .
<http://id.ukpds.org/DEREMY> <http://id.ukpds.org/schema/personOtherNames> ""Bernard"" .
<http://id.ukpds.org/DEREMY> <http://id.ukpds.org/schema/partyMemberHasPartyMembership> <http://id.ukpds.org/xiOjcfHS> .
<http://id.ukpds.org/DEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/kGCr7yVH> .
<http://id.ukpds.org/u0mXpY2m> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/MemberImage> .
<http://id.ukpds.org/TuDsm6mf> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/ConstituencyGroup> .
<http://id.ukpds.org/TuDsm6mf> <http://id.ukpds.org/schema/constituencyGroupName> ""Islington North"" .
<http://id.ukpds.org/TuDsm6mf> <http://id.ukpds.org/schema/constituencyGroupStartDate> ""1983-06-09""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/TuDsm6mf> <http://id.ukpds.org/schema/constituencyGroupEndDate> ""1997-05-01""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/kGCr7yVH> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/kGCr7yVH> <http://id.ukpds.org/schema/incumbencyEndDate> ""1987-06-11""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/kGCr7yVH> <http://id.ukpds.org/schema/incumbencyStartDate> ""1983-06-09""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/kGCr7yVH> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/mH68Wbzd> .
<http://id.ukpds.org/mH68Wbzd> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/HouseSeat> .
<http://id.ukpds.org/mH68Wbzd> <http://id.ukpds.org/schema/houseSeatHasConstituencyGroup> <http://id.ukpds.org/TuDsm6mf> .
<http://id.ukpds.org/mH68Wbzd> <http://id.ukpds.org/schema/houseSeatHasHouse> <http://id.ukpds.org/Kz7ncmrt> .
<http://id.ukpds.org/891w1b1k> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/Party> .
<http://id.ukpds.org/891w1b1k> <http://id.ukpds.org/schema/partyName> ""Labour"" .
<http://id.ukpds.org/xiOjcfHS> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/PartyMembership> .
<http://id.ukpds.org/xiOjcfHS> <http://id.ukpds.org/schema/partyMembershipStartDate> ""1983-06-09""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/xiOjcfHS> <http://id.ukpds.org/schema/partyMembershipEndDate> ""2015-03-30""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/xiOjcfHS> <http://id.ukpds.org/schema/partyMembershipHasParty> <http://id.ukpds.org/891w1b1k> .
<http://id.ukpds.org/Kz7ncmrt> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/House> .
<http://id.ukpds.org/Kz7ncmrt> <http://id.ukpds.org/schema/houseName> ""House of Commons"" .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/partyMemberHasPartyMembership> <http://id.ukpds.org/whVj0EG6> .
<http://id.ukpds.org/whVj0EG6> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/PartyMembership> .
<http://id.ukpds.org/whVj0EG6> <http://id.ukpds.org/schema/partyMembershipStartDate> ""2015-05-07""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/whVj0EG6> <http://id.ukpds.org/schema/partyMembershipEndDate> ""2017-05-03""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/whVj0EG6> <http://id.ukpds.org/schema/partyMembershipHasParty> <http://id.ukpds.org/891w1b1k> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/partyMemberHasPartyMembership> <http://id.ukpds.org/uLNi5UkB> .
<http://id.ukpds.org/uLNi5UkB> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/PartyMembership> .
<http://id.ukpds.org/uLNi5UkB> <http://id.ukpds.org/schema/partyMembershipStartDate> ""2017-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/uLNi5UkB> <http://id.ukpds.org/schema/partyMembershipHasParty> <http://id.ukpds.org/891w1b1k> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/TVu8LFst> .
<http://id.ukpds.org/TVu8LFst> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/TVu8LFst> <http://id.ukpds.org/schema/incumbencyEndDate> ""1992-04-09""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/TVu8LFst> <http://id.ukpds.org/schema/incumbencyStartDate> ""1987-06-11""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/TVu8LFst> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/mH68Wbzd> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/cPGNU6ZH> .
<http://id.ukpds.org/cPGNU6ZH> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/cPGNU6ZH> <http://id.ukpds.org/schema/incumbencyEndDate> ""1997-05-01""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/cPGNU6ZH> <http://id.ukpds.org/schema/incumbencyStartDate> ""1992-04-09""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/cPGNU6ZH> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/mH68Wbzd> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/iA1cHCIH> .
<http://id.ukpds.org/1HnT8xin> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/ConstituencyGroup> .
<http://id.ukpds.org/1HnT8xin> <http://id.ukpds.org/schema/constituencyGroupName> ""Islington North"" .
<http://id.ukpds.org/1HnT8xin> <http://id.ukpds.org/schema/constituencyGroupStartDate> ""1997-05-01""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/1HnT8xin> <http://id.ukpds.org/schema/constituencyGroupEndDate> ""2010-05-06""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/iA1cHCIH> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/iA1cHCIH> <http://id.ukpds.org/schema/incumbencyEndDate> ""2001-06-07""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/iA1cHCIH> <http://id.ukpds.org/schema/incumbencyStartDate> ""1997-05-01""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/iA1cHCIH> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/B3nuidv4> .
<http://id.ukpds.org/B3nuidv4> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/HouseSeat> .
<http://id.ukpds.org/B3nuidv4> <http://id.ukpds.org/schema/houseSeatHasConstituencyGroup> <http://id.ukpds.org/1HnT8xin> .
<http://id.ukpds.org/B3nuidv4> <http://id.ukpds.org/schema/houseSeatHasHouse> <http://id.ukpds.org/Kz7ncmrt> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/kHn3mOQI> .
<http://id.ukpds.org/kHn3mOQI> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/kHn3mOQI> <http://id.ukpds.org/schema/incumbencyEndDate> ""2005-05-05""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/kHn3mOQI> <http://id.ukpds.org/schema/incumbencyStartDate> ""2001-06-07""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/kHn3mOQI> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/B3nuidv4> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/P88Ubpa2> .
<http://id.ukpds.org/P88Ubpa2> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/P88Ubpa2> <http://id.ukpds.org/schema/incumbencyEndDate> ""2010-05-06""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/P88Ubpa2> <http://id.ukpds.org/schema/incumbencyStartDate> ""2005-05-05""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/P88Ubpa2> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/B3nuidv4> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/FbNu8cEu> .
<http://id.ukpds.org/06ZfKsSW> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/ConstituencyGroup> .
<http://id.ukpds.org/06ZfKsSW> <http://id.ukpds.org/schema/constituencyGroupName> ""Islington North"" .
<http://id.ukpds.org/06ZfKsSW> <http://id.ukpds.org/schema/constituencyGroupStartDate> ""2010-05-06""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/FbNu8cEu> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/FbNu8cEu> <http://id.ukpds.org/schema/incumbencyEndDate> ""2015-03-30""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/FbNu8cEu> <http://id.ukpds.org/schema/incumbencyStartDate> ""2010-05-06""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/FbNu8cEu> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/VKUYDXoa> .
<http://id.ukpds.org/VKUYDXoa> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/HouseSeat> .
<http://id.ukpds.org/VKUYDXoa> <http://id.ukpds.org/schema/houseSeatHasConstituencyGroup> <http://id.ukpds.org/06ZfKsSW> .
<http://id.ukpds.org/VKUYDXoa> <http://id.ukpds.org/schema/houseSeatHasHouse> <http://id.ukpds.org/Kz7ncmrt> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/tXVTiEYq> .
<http://id.ukpds.org/tXVTiEYq> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/tXVTiEYq> <http://id.ukpds.org/schema/incumbencyEndDate> ""2017-05-03""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/tXVTiEYq> <http://id.ukpds.org/schema/incumbencyStartDate> ""2015-05-07""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/tXVTiEYq> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/VKUYDXoa> .
<http://id.ukpds.org/BEREMY> <http://id.ukpds.org/schema/memberHasIncumbency> <http://id.ukpds.org/yKbi7ikQ> .
<http://id.ukpds.org/FeCebO0j> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/ContactPoint> .
<http://id.ukpds.org/FeCebO0j> <http://id.ukpds.org/schema/email> ""leader@labour.org.uk"" .
<http://id.ukpds.org/FeCebO0j> <http://id.ukpds.org/schema/phoneNumber> ""020 7219 3545"" .
<http://id.ukpds.org/FeCebO0j> <http://id.ukpds.org/schema/contactPointHasPostalAddress> <http://id.ukpds.org/hytooZR3> .
<http://id.ukpds.org/hytooZR3> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/PostalAddress> .
<http://id.ukpds.org/hytooZR3> <http://id.ukpds.org/schema/addressLine1> ""House of Commons"" .
<http://id.ukpds.org/hytooZR3> <http://id.ukpds.org/schema/addressLine2> ""London"" .
<http://id.ukpds.org/hytooZR3> <http://id.ukpds.org/schema/postCode> ""SW1A 0AA"" .
<http://id.ukpds.org/yKbi7ikQ> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/SeatIncumbency> .
<http://id.ukpds.org/yKbi7ikQ> <http://id.ukpds.org/schema/incumbencyStartDate> ""2017-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/yKbi7ikQ> <http://id.ukpds.org/schema/seatIncumbencyHasHouseSeat> <http://id.ukpds.org/VKUYDXoa> .
<http://id.ukpds.org/yKbi7ikQ> <http://id.ukpds.org/schema/incumbencyHasContactPoint> <http://id.ukpds.org/FeCebO0j> .
";
            var graph = new Graph();
            graph.LoadFromString(triples);
            return graph;
        }
        [HttpGet]
        public Graph committee_index()
        {
            var triples = @"
<http://id.ukpds.org/TRADECOMMITTEE> <http://id.ukpds.org/schema/formalBodyName> ""Trade Committee"" .
<http://id.ukpds.org/TRADECOMMITTEE> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/FormalBody> .
<http://id.ukpds.org/TRADECOMMITTEE> <http://id.ukpds.org/schema/formalBodyHasHouse> <http://id.ukpds.org/HOUSEOFLORDS> .
<http://id.ukpds.org/HOUSEOFLORDS> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/House> .
<http://id.ukpds.org/HOUSEOFLORDS> <http://id.ukpds.org/schema/houseName> ""House Of Lords"" .
<http://id.ukpds.org/TRADECOMMITTEE> <http://id.ukpds.org/schema/formalBodyStartDate> ""1900-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .

<http://id.ukpds.org/JOBSCOMMITTEE> <http://id.ukpds.org/schema/formalBodyName> ""Jobs Committee"" .
<http://id.ukpds.org/JOBSCOMMITTEE> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/FormalBody> .
<http://id.ukpds.org/JOBSCOMMITTEE> <http://id.ukpds.org/schema/formalBodyHasHouse> <http://id.ukpds.org/HOUSEOFCOMMONS> .
<http://id.ukpds.org/HOUSEOFCOMMONS> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/House> .
<http://id.ukpds.org/HOUSEOFCOMMONS> <http://id.ukpds.org/schema/houseName> ""House Of Commons"" .
<http://id.ukpds.org/JOBSCOMMITTEE> <http://id.ukpds.org/schema/formalBodyStartDate> ""1901-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .

<http://id.ukpds.org/EDUCOMMITTEE> <http://id.ukpds.org/schema/formalBodyName> ""Education Committee"" .
<http://id.ukpds.org/EDUCOMMITTEE> <http://www.w3.org/1999/02/22-rdf-syntax-ns#type> <http://id.ukpds.org/schema/FormalBody> .
<http://id.ukpds.org/EDUCOMMITTEE> <http://id.ukpds.org/schema/formalBodyHasHouse> <http://id.ukpds.org/HOUSEOFCOMMONS> .
<http://id.ukpds.org/EDUCOMMITTEE> <http://id.ukpds.org/schema/formalBodyHasHouse> <http://id.ukpds.org/HOUSEOFLORDS> .
<http://id.ukpds.org/EDUCOMMITTEE> <http://id.ukpds.org/schema/formalBodyStartDate> ""1928-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .
<http://id.ukpds.org/EDUCOMMITTEE> <http://id.ukpds.org/schema/formalBodyEndDate> ""2015-06-08""^^<http://www.w3.org/2001/XMLSchema#date> .


";
            var graph = new Graph();
            graph.LoadFromString(triples);
            return graph;
        }
    }
}
