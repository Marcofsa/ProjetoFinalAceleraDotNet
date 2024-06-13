import { Component, OnInit } from '@angular/core';
import * as XLSX from 'xlsx';
import { ChartmodalComponent } from '../chartmodal/chartmodal.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BalanceData } from './balance.component';


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

  Math = Math;

  constructor(private modalService: NgbModal) { }

  ngOnInit(): void {
    this.saldoDados = [
      {
        idPA: '',
        pontoAtendimento: 'P.A. Londrina',
        local: 'Londrina - PR',
        lastUpdate: '02/04/2024',
        data: '04/06/2024',
        montante: '$5.162,700',
      },
      {
        idPA: '',
        pontoAtendimento: 'P.A. Londrina',
        local: 'Londrina - PR',
        lastUpdate: '01/05/2024',
        data: '25/05/2024',
        montante: '$1,200,000',
      },
      {
        idPA: '',
        pontoAtendimento: 'P.A. São Paulo',
        local: 'Bauru - SP',
        lastUpdate: '07/05/2024',
        data: '25/05/2024',
        montante: '$6,200,000',
      },
    ];
    this.dadosFiltrados = this.saldoDados;
  }

  buscaSaldos(): void {
    this.dadosFiltrados = this.saldoDados.filter(
      (item) => item.pontoAtendimento
        .toLowerCase()
        .includes(this.searchQuery.toLowerCase()) ||
        item.local.toLowerCase().includes(this.searchQuery.toLowerCase())
    );
  }

  // exportaExcel(): void {
  //   const worksheet: XLSX.WorkSheet = XLSX.utils.aoa_to_sheet(
  //     this.dadosFiltrados
  //   );
  //   const workbook: XLSX.WorkBook = {
  //     Sheets: { data: worksheet },
  //     SheetNames: ['data'],
  //   };
  //   XLSX.writeFile(workbook, 'balance_report.xlsx');
  // }

  openChartModal() {
    const modalRef = this.modalService.open(ChartmodalComponent);
  }
}
