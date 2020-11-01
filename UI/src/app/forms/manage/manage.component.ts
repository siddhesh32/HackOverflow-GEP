import { Component, OnInit, TemplateRef, ViewChild, ViewContainerRef, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
    public manageService: ManageService
  ) { }
  ngOnInit() {
    this.route.data.subscribe((data: any) => {
      this.bindData(data.manage);
    })
  }
  bindData(data) {

    this.destroyContainer();
    let manageCards = [];
    if (data && data.length > 0) {
      data.forEach((_data: any) => {
        let manageData = [];
        if (_data && Object.keys(_data) && Object.keys(_data).length > 0) {
          Object.keys(_data).forEach((key: string) => {
            let rowData = [key, _data[key]]
            manageData.push(rowData);
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
}
