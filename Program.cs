<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.Record;
using ParserFortTelecom.DbService;
=======
using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.Record;
using ParserFortTelecom.DbService;
using ParserFortTelecom.Entity;
using ParserFortTelecom.Parsers;
using testparser.Parsers;
>>>>>>> 3667184 (working parser)

class Program
{
    static async Task Main()
    {
        var dbConnection = new DatabaseConnection(); //подключение к бд
<<<<<<< HEAD
        var dbClear = new DatabaseClear(dbConnection); //чистим бд
        dbClear.DeleteSwitchers(); 

        var dbSaver = new DatabaseSaver(dbConnection);

        using HttpClient client = new HttpClient(); 
        var parsermasterman = new MasterManParser(client); //обьявляем парсер
        var switchesmasterman = await parsermasterman.ParseAsync(); // получаем данные
        dbSaver.SaveSwitches(switchesmasterman); // сохраняем в бд
        switchesmasterman.Clear(); // удаляем из памяти ибо нах оно нам надо
=======

        var dbSaver = new DatabaseSaver(dbConnection);
        dbSaver.falseall();
        Console.WriteLine("Данные false");
        using HttpClient client = new HttpClient();

        var parsermasterman = new MasterManParser(client); //обьявляем парсер
        var switchesmasterman = await parsermasterman.ParseAsync(); // получаем данные
        dbSaver.SaveSwitches(switchesmasterman); // сохраняем в бд
>>>>>>> 3667184 (working parser)

        var parseOSNOVO = new OsnovoParser(client);
        var switchesOSNOVO = await parseOSNOVO.ParseAsync();
        dbSaver.SaveSwitches(switchesOSNOVO);
<<<<<<< HEAD
        switchesOSNOVO.Clear();
=======

        var parseNSGATE = new NSGateParser(client);
        var switchesNSGATE = await parseNSGATE.ParseAsync();
        dbSaver.SaveSwitches(switchesNSGATE);

        var parseTFortis = new TFortisParser();
        var switchesTFortis = await parseTFortis.ParseAsync();
        dbSaver.SaveSwitches(switchesTFortis);

        var parseRelion = new RelionParser(client);
        var switchesRelion = await parseRelion.ParseAsync();
        dbSaver.SaveSwitches(switchesRelion);

>>>>>>> 3667184 (working parser)
    }
}