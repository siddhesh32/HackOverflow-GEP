import { CommonModule } from '@angular/common';
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { DetailResolver } from './detail.resolver';
import { DetailComponent } from './detail.component';
import {DetailService} from './detail.service';
export const route: Routes = [
    {
        path: '',
        component: DetailComponent,
        resolve: {detail: DetailResolver}
    }
];
export const routing = RouterModule.forChild(route);
@NgModule({
    imports:[CommonModule, routing, FormsModule, ReactiveFormsModule],
    declarations:[DetailComponent],
    entryComponents:[DetailComponent],
    exports:[DetailComponent],
    providers:[DetailResolver, DetailService]
})
export class DetailModule {
    static entry = DetailComponent;
}