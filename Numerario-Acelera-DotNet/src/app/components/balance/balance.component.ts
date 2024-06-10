import { Component, OnInit } from '@angular/core';
import * as XLSX from 'xlsx';


interface BalanceData {
  pontoAtendimento: string;
  local: string;
  lastUpdate: string;
  data: string;
  montante: string;
}

@Component({
  selector: 'app-balance',
  templateUrl: './balance.component.html',
  styleUrls: ['./balance.component.scss'],
})
export class BalanceComponent implements OnInit {
  saldoDados: BalanceData[] = [];
  dadosFiltrados: BalanceData[] = [];
  searchQuery: string = '';
  paginaAtual: number = 1;
  itensPorPage: number = 10;

  ngOnInit(): void {
    this.saldoDados = [
      {
        pontoAtendimento: 'P.A. Londrina',
        local: 'Londrina - PR',
        lastUpdate: '02/04/2024',
        data: '04/06/2024',
        montante: '$5.162,700',
      },
      {
        pontoAtendimento: 'P.A. Londrina',
        local: 'Londrina - PR',
        lastUpdate: '01/05/2024',
        data: '25/05/2024',
        montante: '$1,200,000',
      },
    ];
    this.dadosFiltrados = this.saldoDados;
  }

  buscaSaldos(): void {
    this.dadosFiltrados = this.saldoDados.filter(
      (item) =>
        item.pontoAtendimento
          .toLowerCase()
          .includes(this.searchQuery.toLowerCase()) ||
        item.local.toLowerCase().includes(this.searchQuery.toLowerCase())
    );
  }

  exportaExcel(): void {
    const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(
      this.dadosFiltrados
    );
    const workbook: XLSX.WorkBook = {
      Sheets: { data: worksheet },
      SheetNames: ['data'],
    };
    XLSX.writeFile(workbook, 'balance_report.xlsx');
  }
}
