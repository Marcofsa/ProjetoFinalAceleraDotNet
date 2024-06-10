import * as XLSX from 'xlsx';

// Define a função que cria o excel
function createExcelReport(data: any[]) {
  const header = [[], [], [], [], [], [], [], [], []];

  const sheetData = [...header, ...data];

  const newBook = XLSX.utils.book_new();
  const toSheetData = XLSX.utils.aoa_to_sheet(sheetData);

  XLSX.utils.book_append_sheet(newBook, toSheetData, 'Report');

  XLSX.writeFile(newBook, 'Relatório.xlsx');
}

const exampleData = [[], [], [], [], [], [], [], [], [], [], [], [], [], []];

createExcelReport(exampleData);
