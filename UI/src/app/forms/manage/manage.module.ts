import { CommonModule } from '@angular/common';
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { ManageComponent } from './manage.component';
import { ManageResolver } from './manage.reolver';
import { ManageService } from './manage.service';
export const route: Routes = [
    {
        path: '',
        component: ManageComponent,
        resolve: {manage: ManageResolver}
    }
];
export const routing = RouterModule.forChild(route);
@NgModule({
    imports:[CommonModule, routing, FormsModule, ReactiveFormsModule],
    declarations:[ManageComponent],
    entryComponents:[ManageComponent],
    exports:[ManageComponent],
    providers:[ManageService, ManageResolver]
})
export class ManageModule {
    static entry = ManageComponent;
}