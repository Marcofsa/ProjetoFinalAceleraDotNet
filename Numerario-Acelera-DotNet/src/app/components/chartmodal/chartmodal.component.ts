import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-chartmodal',
  templateUrl: './chartmodal.component.html',
  styleUrls: ['./chartmodal.component.scss']
})
export class ChartmodalComponent implements OnInit {
  isChartModalOpen: boolean = false;
  chart: any;

  constructor() { }

  ngOnInit(): void { }

  openChartModal() {
    this.isChartModalOpen = true;
    setTimeout(() => this.loadChart(), 0); 
  }

  closeChartModal() {
    this.isChartModalOpen = false;
  }

  loadChart() {
    const ctx = document.getElementById('chartCanvas') as HTMLCanvasElement;
    if (ctx) {
      this.chart = new Chart(ctx, {
        type: 'doughnut',
        data: {
          labels: ['Chrome', 'IE', 'Firefox', 'Safari', 'Opera', 'Navigator'],
          datasets: [{
            data: [55, 15, 10, 10, 7, 3],
            backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#FF9F40', '#4BC0C0', '#9966FF'],
          }]
        },
        options: {
          responsive: true,
        }
      });
    }
  }
}
