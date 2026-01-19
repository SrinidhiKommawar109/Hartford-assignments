import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './components/navbar/navbar';
import { HeaderComponent } from './components/header/header';
import { DescriptionComponent } from './components/description/description';
import { WelcomeBannerComponent } from './components/welcome-banner/welcome-banner';

import { InsuranceProfilesComponent } from './components/insurance-profiles/insurance-profiles';
import { FooterComponent } from './components/footer/footer';

@Component({
  selector: 'app-root',
  standalone: true, 
  imports: [
    RouterOutlet,
    NavbarComponent,
    HeaderComponent,
    WelcomeBannerComponent,
    DescriptionComponent,
    InsuranceProfilesComponent,
    FooterComponent
  ],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App{
  protected readonly title = signal('ang-assign-1');
}
