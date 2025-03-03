using NPOI.HSSF.Record;
using testparser.DbService;

class Program
{
    static async Task Main()
    {
        var dbClear = new DatabaseClear("Host=79.174.89.63;Port=16052;Username=Parkour;Password=1Fz0XuD5nNYV11!;Database=dbParkour");
        dbClear.DeleteSwitchers();
        var parsermasterman = new MasterManParser();
        var switchesmasterman = await parsermasterman.ParseAsync();

        var parseOSNOVO = new OsnovoParser();
        var switchesOSNOVO = await parseOSNOVO.ParseAsync();

        var dbSaver = new DatabaseSaver("Host=79.174.89.63;Port=16052;Username=Parkour;Password=1Fz0XuD5nNYV11!;Database=dbParkour");
        dbSaver.SaveSwitches(switchesmasterman);
        dbSaver.SaveSwitches(switchesOSNOVO);
    }
}