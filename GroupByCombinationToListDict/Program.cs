// See https://aka.ms/new-console-template for more information

using GroupByCombinationToListDict;

var allRestrictionsByTerminalAndDate = new List<TerminalRestriction>();
var allTerminalTimeslotVehiclesInTerminalByDate = new List<TerminalTimeslotVehicle>();

var allRestrictionsByTerminalAndDateIds = allRestrictionsByTerminalAndDate.Select(x => x.Id).ToList();

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


