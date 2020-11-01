import { Component, OnInit, TemplateRef, ViewChild, ViewContainerRef, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ManageService } from './manage.service';

@Component({
  selector: 'app-manage',
  templateUrl: './manage.component.html',
  styleUrls: ['./manage.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ManageComponent implements OnInit {
  @ViewChild('container', { read: ViewContainerRef, static: true }) container: ViewContainerRef;
  @ViewChild('template', { static: true }) template: TemplateRef<any>;
  constructor(
    public route: ActivatedRoute,
    public manageService: ManageService,
    public router :Router
  ) { }
  ngOnInit() {
    debugger;
    this.route.data.subscribe((data: any) => {
      this.bindData(data.manage);
    })
  }
  bindData(data) {

    debugger;
    this.destroyContainer();
    let manageCards = [];
    if (data && data.length > 0) {
      data.forEach((_data: any) => {
        let manageData = [];
        if (_data && Object.values(_data) && Object.values(_data).length > 0) {
          Object.values(_data).forEach((item:any) => {
            if(item.displayName!="partitionKey"){
              let rowData = [item.displayName, item.value]
              manageData.push(rowData);
            }
          });
          manageCards.push(manageData);
        }
        this.loadContainer(manageData);
      });
    }
  }

  loadContainer(data) {
    this.container.createEmbeddedView(this.template, { data });
  }
  destroyContainer() {
    (this.container && this.container.length > 0) && (this.container.clear())
  }
  redirectToView(data){
    var colData= data.find(item => item[0]=="id")
    if(colData != undefined){
    var docId = colData[1];
    localStorage.setItem('docid',docId);
    this.router.navigateByUrl("/pages/create");
    }
   }
}
