import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './shared/components/login/login.component.html',
  styleUrl: './shared/components/login/login.component.css',
})
export class AppComponent {
  title = 'Numerario-Acelera-DotNet';
}
