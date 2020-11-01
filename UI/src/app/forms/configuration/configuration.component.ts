import { Component, OnInit, TemplateRef, ViewChild, ViewContainerRef, ViewEncapsulation } from "@angular/core";
import { ActivatedRoute } from '@angular/router';
import { ConfigurationService } from './configuration.service';

@Component({
    selector: 'app-configuration',
    templateUrl: 'configuration.component.html',
    styleUrls: ['./configuration.component.scss'],
    encapsulation: ViewEncapsulation.None,
})
export class ConfigurationComponent implements OnInit{
    config;
    @ViewChild('container', { read: ViewContainerRef, static: true }) container: ViewContainerRef;
    @ViewChild('template', { static: true }) template: TemplateRef<any>;
    constructor(
        public route: ActivatedRoute,
        public configurationService: ConfigurationService
    ) { }
    ngOnInit(){
        this.route.data.subscribe((data: any) => {
            this.config = data.configuration;
            this.loadFields(this.config);
        });
    }

    loadFields(config) {
        this.destroyContainer();
        if(config && Object.keys(config) && Object.keys(config).length > 0){
            Object.keys(config).forEach((key: string, index: number) => {
                this.loadContainer(key, config[key]);
            })
        }
    }
    loadContainer(formKey,formData){
        this.container.createEmbeddedView(this.template, {formKey, formData});
    }
    destroyContainer(){
        (this.container && this.container.length>0) && (this.container.clear());
    }

    onSubmit() {
       this.configurationService.saveConfig(this.config);
    }

    onReset() {
    }
    ngOnDestroy() { }
}