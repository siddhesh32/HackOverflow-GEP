import { NgModule } from '@angular/core';
import { NbMenuModule } from '@nebular/theme';
import { ThemeModule } from '../@theme/theme.module';
import { PagesComponent } from './pages.component';
import { PagesRoutingModule } from './pages-routing.module';
import { DetailModule } from 'app/forms/detail/detail.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ManageModule } from 'app/forms/manage/manage.module';
import { ConfigurationModule } from 'app/forms/configuration/configuration.module';

@NgModule({
  imports: [
    PagesRoutingModule,
    ThemeModule,
    NbMenuModule,
    DetailModule,
    ReactiveFormsModule,
    ManageModule,
    ConfigurationModule
  ],
  declarations: [
    PagesComponent,
  ],
})
export class PagesModule {
}
