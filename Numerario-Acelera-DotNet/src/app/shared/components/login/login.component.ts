import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  template: `
    <div class="login-container">
      <div class="sidebar">
        <div class="logo">TRANSPORTADORAS</div>
        <div class="menu">
          <a href="#">BRINKS</a>
          <a href="#">PAGAMENTO</a>
          <a href="#">RECEBIMENTO</a>
          <a href="#">PERFIL DA EMPRESA</a>
          <a href="#">PERFIL DO MOTORISTA</a>
        </div>
      </div>
      <div class="main-content">
        <header>
          <div class="transaction-info">
            <span>TRANSPORTADORA</span>
            <span>VALOR MÁXIMO</span>
            <span>VALOR ATUALIZADO</span>
            <span>ÚLTIMA ATUALIZAÇÃO</span>
            <span>DATA DO CORTE</span>
          </div>
          <button class="export-btn">Exportar</button>
        </header>
        <div class="transaction-details">
          <!-- Detalhes da transação aqui -->
        </div>
      </div>
    </div>
  `,
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  // Lógica do componente aqui
}