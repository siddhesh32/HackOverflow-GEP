import { CommonModule } from '@angular/common';
// tslint:disable-next-line: quotemark
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { ConfigurationComponent } from './configuration.component';
import { ConfigurationResolver } from './configuration.resolver';
import { ConfigurationService } from './configuration.service';
export const route: Routes = [
    {
        path: '',
        component: ConfigurationComponent,
        resolve: {configuration: ConfigurationResolver}
    }
];
export const routing = RouterModule.forChild(route);
@NgModule({
    imports:[CommonModule, routing, FormsModule, ReactiveFormsModule],
    declarations:[ConfigurationComponent],
    entryComponents:[ConfigurationComponent],
    exports:[ConfigurationComponent],
    providers:[ConfigurationService, ConfigurationResolver]
})
export class ConfigurationModule {
    static entry = ConfigurationComponent;
}