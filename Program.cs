using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.Record;
using ParserFortTelecom.DbService;

class Program
{
    static async Task Main()
    {
        var dbConnection = new DatabaseConnection(); //подключение к бд
        var dbClear = new DatabaseClear(dbConnection); //чистим бд
        dbClear.DeleteSwitchers(); 

        var dbSaver = new DatabaseSaver(dbConnection);

        using HttpClient client = new HttpClient(); 
        var parsermasterman = new MasterManParser(client); //обьявляем парсер
        var switchesmasterman = await parsermasterman.ParseAsync(); // получаем данные
        dbSaver.SaveSwitches(switchesmasterman); // сохраняем в бд
        switchesmasterman.Clear(); // удаляем из памяти ибо нах оно нам надо

        var parseOSNOVO = new OsnovoParser(client);
        var switchesOSNOVO = await parseOSNOVO.ParseAsync();
        dbSaver.SaveSwitches(switchesOSNOVO);
        switchesOSNOVO.Clear();
    }
}