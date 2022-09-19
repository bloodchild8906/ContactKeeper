using System;

namespace ContactKeeper.Domain.Entities
{
    public enum DialingCodes
    {
        [DialCode("93", "AF", "AFG")]
        Afghanistan,
        [DialCode("355", "AL", "ALB")]
        Albania,
        [DialCode("213", "DZ", "DZA")]
        Algeria,
        [DialCode("1-684", "AS", "ASM")]
        AmericanSamoa,
        [DialCode("376", "AD", "AND")]
        Andorra,
        [DialCode("244", "AO", "AGO")]
        Angola,
        [DialCode("1-264", "AI", "AIA")]
        Anguilla,
        [DialCode("672", "AQ", "ATA")]
        Antarctica,
        [DialCode("1-268", "AG", "ATG")]
        Antigua,
        [DialCode("1-268", "AG", "ATG")]
        Barbuda,
        [DialCode("54", "AR", "ARG")]
        Argentina,
        [DialCode("374", "AM", "ARM")]
        Armenia,
        [DialCode("297", "AW", "ABW")]
        Aruba,
        [DialCode("61", "AU", "AUS")]
        Australia,
        [DialCode("43", "AT", "AUT")]
        Austria,
        [DialCode("994", "AZ", "AZE")]
        Azerbaijan,
        [DialCode("1-242", "BS", "BHS")]
        Bahamas,
        [DialCode("973", "BH", "BHR")]
        Bahrain,
        [DialCode("880", "BD", "BGD")]
        Bangladesh,
        [DialCode("1-246", "BB", "BRB")]
        Barbados,
        [DialCode("375", "BY", "BLR")]
        Belarus,
        [DialCode("32", "BE", "BEL")]
        Belgium,
        [DialCode("501", "BZ", "BLZ")]
        Belize,
        [DialCode("229", "BJ", "BEN")]
        Benin,
        [DialCode("1-441", "BM", "BMU")]
        Bermuda,
        [DialCode("975", "BT", "BTN")]
        Bhutan,
        [DialCode("591", "BO", "BOL")]
        Bolivia,
        [DialCode("387", "BA", "BIH")]
        Bosnia,
        [DialCode("387", "BA", "BIH")]
        Herzegovina,
        [DialCode("267", "BW", "BWA")]
        Botswana,
        [DialCode("55", "BR", "BRA")]
        Brazil,
        [DialCode("246", "IO", "IOT")]
        BritishIndianOceanTerritory,
        [DialCode("1-284", "VG", "VGB")]
        BritishVirginIslands,
        [DialCode("673", "BN", "BRN")]
        Brunei,
        [DialCode("359", "BG", "BGR")]
        Bulgaria,
        [DialCode("226", "BF", "BFA")]
        BurkinaFaso,
        [DialCode("95", "MM", "MMR")]
        Burundi,
        [DialCode("257", "BI", "BDI")]
        Cambodia,
        [DialCode("855", "KH", "KHM")]
        Myanmar,
        [DialCode("237", "CM", "CMR")]
        Cameroon,
        [DialCode("1", "CA", "CAN")]
        Canada,
        [DialCode("238", "CV", "CPV")]
        CapeVerde,
        [DialCode("1-345", "KY", "CYM")]
        CaymanIslands,
        [DialCode("236", "CF", "CAF")]
        CentralAfricanRepublic,
        [DialCode("235", "TD", "TCD")]
        Chad,
        [DialCode("56", "CL", "CHL")]
        Chile,
        [DialCode("86", "CN", "CHN")]
        China,
        [DialCode("61", "CX", "CXR")]
        ChristmasIsland,
        [DialCode("61", "CC", "CCK")]
        CocosIslands,
        [DialCode("57", "CO", "COL")]
        Colombia,
        [DialCode("269", "KM", "COM")]
        Comoros,
        [DialCode("242", "CG", "COG")]
        RepublicOfTheCongo,
        [DialCode("243", "CD", "COD")]
        DemocraticRepublicOfTheCongo,
        [DialCode("682", "CK", "COK")]
        CookIslands,
        [DialCode("506", "CR", "CRI")]
        CostaRica,
        [DialCode("385", "HR", "HRV")]
        Croatia,
        [DialCode("53", "CU", "CUB")]
        Cuba,
        [DialCode("599", "CW", "CUW")]
        Curacao,
        [DialCode("357", "CY", "CYP")]
        Cyprus,
        [DialCode("420", "CZ", "CZE")]
        CzechRepublic,
        [DialCode("45", "DK", "DNK")]
        Denmark,
        [DialCode("253", "DJ", "DJI")]
        Djibouti,
        [DialCode("1-767", "DM", "DMA")]
        Dominica,
        [DialCode("1-809,1-829,1-849", "DO", "DOM")]
        DominicanRepublic,
        [DialCode("670", "TL", "TLS")]
        EastTimor,
        [DialCode("593", "EC", "ECU")]
        Ecuador,
        [DialCode("20", "EG", "EGY")]
        Egypt,
        [DialCode("503", "SV", "SLV")]
        ElSalvador,
        [DialCode("240", "GQ", "GNQ")]
        EquatorialGuinea,
        [DialCode("291", "ER", "ERI")]
        Eritrea,
        [DialCode("372", "EE", "EST")]
        Estonia,
        [DialCode("251", "ET", "ETH")]
        Ethiopia,
        [DialCode("500", "FK", "FLK")]
        FalklandIslands,
        [DialCode("298", "FO", "FRO")]
        FaroeIslands,
        [DialCode("679", "FJ", "FJI")]
        Fiji,
        [DialCode("358", "FI", "FIN")]
        Finland,
        [DialCode("33", "FR", "FRA")]
        France,
        [DialCode("689", "PF", "PYF")]
        FrenchPolynesia,
        [DialCode("241", "GA", "GAB")]
        Gabon,
        [DialCode("220", "GM", "GMB")]
        Gambia,
        [DialCode("995", "GE", "GEO")]
        Georgia,
        [DialCode("49", "DE", "DEU")]
        Germany,
        [DialCode("233", "GH", "GHA")]
        Ghana,
        [DialCode("350", "GI", "GIB")]
        Gibraltar,
        [DialCode("30", "GR", "GRC")]
        Greece,
        [DialCode("299", "GL", "GRL")]
        Greenland,
        [DialCode("1-473", "GD", "GRD")]
        Grenada,
        [DialCode("1-671", "GU", "GUM")]
        Guam,
        [DialCode("502", "GT", "GTM")]
        Guatemala,
        [DialCode("44-1481", "GG", "GGY")]
        Guernsey,
        [DialCode("224", "GN", "GIN")]
        Guinea,
        [DialCode("245", "GW", "GNB")]
        GuineaBissau,
        [DialCode("592", "GY", "GUY")]
        Guyana,
        [DialCode("509", "HT", "HTI")]
        Haiti,
        [DialCode("504", "HN", "HND")]
        Honduras,
        [DialCode("852", "HK", "HKG")]
        HongKong,
        [DialCode("36", "HU", "HUN")]
        Hungary,
        [DialCode("354", "IS", "ISL")]
        Iceland,
        [DialCode("91", "IN", "IND")]
        India,
        [DialCode("62", "ID", "IDN")]
        Indonesia,
        [DialCode("98", "IR", "IRN")]
        Iran,
        [DialCode("964", "IQ", "IRQ")]
        Iraq,
        [DialCode("353", "IE", "IRL")]
        Ireland,
        [DialCode("44-1624", "IM", "IMN")]
        IsleOfMan,
        [DialCode("972", "IL", "ISR")]
        Israel,
        [DialCode("39", "IT", "ITA")]
        Italy,
        [DialCode("225", "CI", "CIV")]
        IvoryCoast,
        [DialCode("1-876", "JM", "JAM")]
        Jamaica,
        [DialCode("81", "JP", "JPN")]
        Japan,
        [DialCode("44-1534", "JE", "JEY")]
        Jersey,
        [DialCode("962", "JO", "JOR")]
        Jordan,
        [DialCode("7", "KZ", "KAZ")]
        Kazakhstan,
        [DialCode("254", "KE", "KEN")]
        Kenya,
        [DialCode("686", "KI", "KIR")]
        Kiribati,
        [DialCode("383", "XK", "XKX")]
        Kosovo,
        [DialCode("965", "KW", "KWT")]
        Kuwait,
        [DialCode("996", "KG", "KGZ")]
        Kyrgyzstan,
        [DialCode("856", "LA", "LAO")]
        Laos,
        [DialCode("371", "LV", "LVA")]
        Latvia,
        [DialCode("961", "LB", "LBN")]
        Lebanon,
        [DialCode("266", "LS", "LSO")]
        Lesotho,
        [DialCode("231", "LR", "LBR")]
        Liberia,
        [DialCode("218", "LY", "LBY")]
        Libya,
        [DialCode("423", "LI", "LIE")]
        Liechtenstein,
        [DialCode("370", "LT", "LTU")]
        Lithuania,
        [DialCode("352", "LU", "LUX")]
        Luxembourg,
        [DialCode("853", "MO", "MAC")]
        Macau,
        [DialCode("389", "MK", "MKD")]
        Macedonia,
        [DialCode("261", "MG", "MDG")]
        Madagascar,
        [DialCode("265", "MW", "MWI")]
        Malawi,
        [DialCode("60", "MY", "MYS")]
        Malaysia,
        [DialCode("960", "MV", "MDV")]
        Maldives,
        [DialCode("223", "ML", "MLI")]
        Mali,
        [DialCode("356", "MT", "MLT")]
        Malta,
        [DialCode("692", "MH", "MHL")]
        MarshallIslands,
        [DialCode("222", "MR", "MRT")]
        Mauritania,
        [DialCode("230", "MU", "MUS")]
        Mauritius,
        [DialCode("262", "YT", "MYT")]
        Mayotte,
        [DialCode("52", "MX", "MEX")]
        Mexico,
        [DialCode("691", "FM", "FSM")]
        Micronesia,
        [DialCode("373", "MD", "MDA")]
        Moldova,
        [DialCode("377", "MC", "MCO")]
        Monaco,
        [DialCode("976", "MN", "MNG")]
        Mongolia,
        [DialCode("382", "ME", "MNE")]
        Montenegro,
        [DialCode("1-664", "MS", "MSR")]
        Montserrat,
        [DialCode("212", "MA", "MAR")]
        Morocco,
        [DialCode("258", "MZ", "MOZ")]
        Mozambique,
        [DialCode("264", "NA", "NAM")]
        Namibia,
        [DialCode("674", "NR", "NRU")]
        Nauru,
        [DialCode("977", "NP", "NPL")]
        Nepal,
        [DialCode("31", "NL", "NLD")]
        Netherlands,
        [DialCode("599", "AN", "ANT")]
        NetherlandsAntilles,
        [DialCode("687", "NC", "NCL")]
        NewCaledonia,
        [DialCode("64", "NZ", "NZL")]
        NewZealand,
        [DialCode("505", "NI", "NIC")]
        Nicaragua,
        [DialCode("227", "NE", "NER")]
        Niger,
        [DialCode("234", "NG", "NGA")]
        Nigeria,
        [DialCode("683", "NU", "NIU")]
        Niue,
        [DialCode("1-670", "MP", "MNP")]
        NorthernMarianaIslands,
        [DialCode("850", "KP", "PRK")]
        NorthKorea,
        [DialCode("47", "NO", "NOR")]
        Norway,
        [DialCode("968", "OM", "OMN")]
        Oman,
        [DialCode("92", "PK", "PAK")]
        Pakistan,
        [DialCode("680", "PW", "PLW")]
        Palau,
        [DialCode("970", "PS", "PSE")]
        Palestine,
        [DialCode("507", "PA", "PAN")]
        Panama,
        [DialCode("675", "PG", "PNG")]
        PapuaNewGuinea,
        [DialCode("595", "PY", "PRY")]
        Paraguay,
        [DialCode("51", "PE", "PER")]
        Peru,
        [DialCode("63", "PH", "PHL")]
        Philippines,
        [DialCode("64", "PN", "PCN")]
        Pitcairn,
        [DialCode("48", "PL", "POL")]
        Poland,
        [DialCode("351", "PT", "PRT")]
        Portugal,
        [DialCode("1-787,1-939", "PR", "PRI")]
        PuertoRico,
        [DialCode("974", "QA", "QAT")]
        Qatar,
        [DialCode("262", "RE", "REU")]
        Reunion,
        [DialCode("40", "RO", "ROU")]
        Romania,
        [DialCode("7", "RU", "RUS")]
        Russia,
        [DialCode("250", "RW", "RWA")]
        Rwanda,
        [DialCode("590", "BL", "BLM")]
        SaintBarthelemy,
        [DialCode("378", "SM", "SMR")]
        SanMarino,
        [DialCode("239", "ST", "STP")]
        SaoTome,
        [DialCode("239", "ST", "STP")]
        Principe,
        [DialCode("966", "SA", "SAU")]
        SaudiArabia,
        [DialCode("221", "SN", "SEN")]
        Senegal,
        [DialCode("381", "RS", "SRB")]
        Serbia,
        [DialCode("248", "SC", "SYC")]
        Seychelles,
        [DialCode("232", "SL", "SLE")]
        SierraLeone,
        [DialCode("65", "SG", "SGP")]
        Singapore,
        [DialCode("1-721", "SX", "SXM")]
        SintMaarten,
        [DialCode("421", "SK", "SVK")]
        Slovakia,
        [DialCode("386", "SI", "SVN")]
        Slovenia,
        [DialCode("677", "SB", "SLB")]
        SolomonIslands,
        [DialCode("252", "SO", "SOM")]
        Somalia,
        [DialCode("27", "ZA", "ZAF")]
        SouthAfrica,
        [DialCode("82", "KR", "KOR")]
        SouthKorea,
        [DialCode("211", "SS", "SSD")]
        SouthSudan,
        [DialCode("34", "ES", "ESP")]
        Spain,
        [DialCode("94", "LK", "LKA")]
        SriLanka,
        [DialCode("290", "SH", "SHN")]
        SaintHelena,
        [DialCode("1-869", "KN", "KNA")]
        SaintKitts,
        [DialCode("1-869", "KN", "KNA")]
        Nevis,
        [DialCode("1-758", "LC", "LCA")]
        SaintLucia,
        [DialCode("590", "MF", "MAF")]
        SaintMartin,
        [DialCode("508", "PM", "SPM")]
        SaintPierre,
        [DialCode("508", "PM", "SPM")]
        Miquelon,
        [DialCode("1-784", "VC", "VCT")]
        SaintVincent,
        [DialCode("1-784", "VC", "VCT")]
        TheGrenadines,
        [DialCode("249", "SD", "SDN")]
        Sudan,
        [DialCode("597", "SR", "SUR")]
        Suriname,
        [DialCode("47", "SJ", "SJM")]
        Svalbard,
        [DialCode("47", "SJ", "SJM")]
        JanMayen,
        [DialCode("268", "SZ", "SWZ")]
        Swaziland,
        [DialCode("46", "SE", "SWE")]
        Sweden,
        [DialCode("41", "CH", "CHE")]
        Switzerland,
        [DialCode("963", "SY", "SYR")]
        Syria,
        [DialCode("886", "TW", "TWN")]
        Taiwan,
        [DialCode("992", "TJ", "TJK")]
        Tajikistan,
        [DialCode("255", "TZ", "TZA")]
        Tanzania,
        [DialCode("66", "TH", "THA")]
        Thailand,
        [DialCode("228", "TG", "TGO")]
        Togo,
        [DialCode("690", "TK", "TKL")]
        Tokelau,
        [DialCode("676", "TO", "TON")]
        Tonga,
        [DialCode("1-868", "TT", "TTO")]
        Trinidad,
        [DialCode("1-868", "TT", "TTO")]
        Tobago,
        [DialCode("216", "TN", "TUN")]
        Tunisia,
        [DialCode("90", "TR", "TUR")]
        Turkey,
        [DialCode("993", "TM", "TKM")]
        Turkmenistan,
        [DialCode("1-649", "TC", "TCA")]
        Turks,
        [DialCode("1-649", "TC", "TCA")]
        CaicosIslands,
        [DialCode("688", "TV", "TUV")]
        Tuvalu,
        [DialCode("971", "AE", "ARE")]
        UnitedArabEmirates,
        [DialCode("256", "UG", "UGA")]
        Uganda,
        [DialCode("44", "GB", "GBR")]
        UnitedKingdom,
        [DialCode("380", "UA", "UKR")]
        Ukraine,
        [DialCode("598", "UY", "URY")]
        Uruguay,
        [DialCode("1", "US", "USA")]
        UnitedStates,
        [DialCode("998", "UZ", "UZB")]
        Uzbekistan,
        [DialCode("678", "VU", "VUT")]
        Vanuatu,
        [DialCode("379", "VA", "VAT")]
        Vatican,
        [DialCode("58", "VE", "VEN")]
        Venezuela,
        [DialCode("84", "VN", "VNM")]
        Vietnam,
        [DialCode("1-340", "VI", "VIR")]
        USVirginIslands,
        [DialCode("681", "WF", "WLF")]
        Wallis,
        [DialCode("681", "WF", "WLF")]
        Futuna,
        [DialCode("212", "EH", "ESH")]
        WesternSahara,
        [DialCode("967", "YE", "YEM")]
        Yemen,
        [DialCode("260", "ZM", "ZMB")]
        Zambia,
        [DialCode("263", "ZW", "ZWE")]
        Zimbabwe
    }
}
