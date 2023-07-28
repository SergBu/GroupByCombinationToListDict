// See https://aka.ms/new-console-template for more information

using GroupByCombinationToListDict;

var allRestrictionsByTerminalAndDate = new List<TerminalRestriction>();
var allTerminalTimeslotVehiclesInTerminalByDate = new List<TerminalTimeslotVehicle>();

var allRestrictionsByTerminalAndDateIds = allRestrictionsByTerminalAndDate.Select(x => x.Id).ToList();

//example 1
var vehiclesInTerminalByDateWithoutQupta = (from a in allTerminalTimeslotVehiclesInTerminalByDate
                                            where a.Deleted == null ? !allRestrictionsByTerminalAndDateIds.Intersect(a.RestrictionIds).Any() : !allRestrictionsByTerminalAndDateIds.Intersect(a.RestrictionsIdsInfo).Any()
                                            select a).ToList();

var allVehiclesGroupByCrop = vehiclesInTerminalByDateWithoutQupta
    .GroupBy(x => new
    {
        x.CropId,
        combination = x.CombinationId
    }).ToDictionary(x => x.Key, x => x.ToList());

foreach (var vehiclesWithCrop in allVehiclesGroupByCrop)
{
    var CropId = vehiclesWithCrop.Key.CropId ?? 0;
    var CombinationId = vehiclesWithCrop.Key.combination;
    var Vehicles = vehiclesWithCrop.Value;
}

//example 2
var allDirectQuotas = new List<TerminalRestriction>(); ;

var quotasGroupByCrop = (from a in allDirectQuotas
                         group a by new
                         {
                             a.Crops.FirstOrDefault()?.CropId,
                             a.TerminalGateId
                         } into grouped
                         select grouped
                        ).ToDictionary(x => (x.Key.CropId.ToString() + ',' + x.Key.TerminalGateId), x => x.ToList());


foreach (var key in quotasGroupByCrop.Select(x => x.Key).ToList())
{
    var quotasByCropId = quotasGroupByCrop[key];

    var cropId = Convert.ToInt32(key.Split(',').Take(1).FirstOrDefault());

    var terminalGateId = Convert.ToInt32(key.Split(',').Skip(1).Take(1).FirstOrDefault());

    var quotaFromTerminalToOwner = new TerminalRestriction
    {
        TerminalId = 1,
        MaxVehiclesCount = quotasByCropId.Sum(x => x.MaxVehiclesCount),
        VehiclesCount = quotasByCropId.Sum(x => x.MaxVehiclesCount),
        CropId = cropId,
        TerminalGateId = terminalGateId,
    };

    //await context.AddAsync(quotaFromTerminalToOwner);
    //await context.SaveChangesAsync();
}

