import { Component } from '@angular/core';

@Component({
  selector: 'app-chartmodal',
  templateUrl: './chartmodal.component.html',
  styleUrls: ['./chartmodal.component.scss'],
})
export class ChartmodalComponent {
  isChartModalOpen: boolean = false;

  constructor() {}

  openChartModal() {
    this.isChartModalOpen = true;
  }

  closeChartModal() {
    this.isChartModalOpen = false;
  }
}
