using ExcelDataReader;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using garbage_collection.Models;
using garbage_collection.Data;

public class ExcelService
{
    private readonly AppDbContext _context;

    public ExcelService(AppDbContext context)
    {
        _context = context;
    }

    public async Task ImportExcelData(string filePath)
    {
    }
}
