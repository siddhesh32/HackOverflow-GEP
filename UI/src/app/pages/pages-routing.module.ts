import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { PagesComponent } from './pages.component';
import { ManageComponent } from 'app/forms/manage/manage.component';
import { ConfigurationComponent } from 'app/forms/configuration/configuration.component';

const routes: Routes = [{
  path: '',
  component: PagesComponent,
  children: [
    {
      path: 'create',
      loadChildren: () => import('../forms/detail/detail.module')
        .then(m => m.DetailModule),
    },
    {
      path: 'manage',
      loadChildren: () => import('../forms/manage/manage.module')
        .then(m => m.ManageModule),
    },
    {
      path: 'configuration',
      loadChildren: () => import('../forms/configuration/configuration.module')
        .then(m => m.ConfigurationModule),
    },
    {
      path: '',
      redirectTo: 'manage',
      pathMatch: 'full',
    },
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {
}
