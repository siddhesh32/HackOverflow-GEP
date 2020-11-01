import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DetailService } from './detail.service';
@Component({
    // tslint:disable-next-line: component-selector
    selector: 'app-detail',
    templateUrl: 'detail.component.html',
    styleUrls: ['./detail.component.scss'],
    encapsulation: ViewEncapsulation.None,
})
export class DetailComponent implements OnInit, OnDestroy {
    constructor(
        private formBuilder: FormBuilder,
        public route: ActivatedRoute,
        public detailService: DetailService
    ) { }
    subscription: Subscription = new Subscription();
    registerForm: FormGroup;
    submitted = false;
    config: any;
    ngOnInit() {
        this.route.data.subscribe((data: any) => {
            this.config = data.detail.config;
            this.registerForm = this.formBuilder.group({
                documentType: [data.detail.data.documentType, Validators.required],
                documentName: [data.detail.data.documentName, Validators.required],
                itemName: [data.detail.data.itemName, Validators.required],
                category: [data.detail.data.category, [Validators.required]],
                businessUnit: [data.detail.data.businessUnit, [Validators.required]],
                region: [data.detail.data.region, Validators.required],
            }
            );
        });
        this.setDefault();
    }

    setDefault(){
        this.registerForm = this.formBuilder.group({
            documentType: ['', Validators.required],
            documentName: ['', Validators.required],
            itemName: ['', Validators.required],
            category: ['', [Validators.required]],
            businessUnit: ['', [Validators.required]],
            region: ['', Validators.required],
        }
        );
    }

    // convenience getter for easy access to form fields
    get f() { return this.registerForm.controls; }

    onSubmit() {
        this.submitted = true;
        this.detailService.saveData(this.registerForm.value)
        // stop here if form is invalid
        if (this.registerForm.invalid) {

            // this.detailService.saveData(JSON.stringify(this.registerForm.value, null, 4))
            return;
        }
    }

    onReset() {
        this.submitted = false;
        this.registerForm.reset();
    }
    ngOnDestroy() { }
}