import { Component, OnInit, AfterViewChecked } from '@angular/core';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-chartmodal',
  templateUrl: './chartmodal.component.html',
  styleUrls: ['./chartmodal.component.scss'],
})
export class ChartmodalComponent implements AfterViewChecked {
  isChartModalOpen: boolean = false;
  chart: any;

  constructor() {}

  ngAfterViewChecked(): void {
    if (this.isChartModalOpen && !this.chart) {
      this.createChart();
    }
  }

  openChartModal() {
    this.isChartModalOpen = true;
  }

  closeChartModal() {
    this.isChartModalOpen = false;
    if (this.chart) {
      this.chart.destroy();  // Destroy chart to avoid duplication
      this.chart = null;
    }
  }

  createChart() {
    const ctx = document.getElementById('browserUsageChart') as HTMLCanvasElement;
    if (ctx) {
      this.chart = new Chart(ctx, {
        type: 'doughnut',
        data: {
          labels: ['Chrome', 'IE', 'FireFox', 'Safari', 'Opera', 'Navigator'],
          datasets: [
            {
              data: [30, 20, 10, 25, 10, 5], // Example data
              backgroundColor: [
                '#FF6384',
                '#36A2EB',
                '#FFCE56',
                '#4BC0C0',
                '#9966FF',
                '#C9CBCF'
              ],
              hoverBackgroundColor: [
                '#FF6384',
                '#36A2EB',
                '#FFCE56',
                '#4BC0C0',
                '#9966FF',
                '#C9CBCF'
              ]
            }
          ]
        },
        options: {
          responsive: true,
          maintainAspectRatio: false
        }
      });
    }
  }
}
