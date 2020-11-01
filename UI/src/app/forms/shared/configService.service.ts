import { Injectable, OnDestroy } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({providedIn: 'root'})
export class ConfigService implements OnDestroy {

    config
    manageData: any[] = [];
    saveConfig(config){
      debugger;
        this.baseservice.postData("http://localhost:59010/api/SaveFieldConfiguration",config,{}).subscribe();
    }
    getConfig(){
        return this.baseservice.getData("http://localhost:59010/api/GetFieldConfiguration?Id=FieldConfig-0",{});
    }
    setManageData(data){
        let newData: any = {};
        if(data && Object.keys(data) && Object.keys(data).length > 0 && data.config) {
            Object.keys(data.config).forEach((key: any)=> {
                newData[data.config[key]] = data.data[key];
            })

        }
        this.manageData.push(newData);
    }
    getManageData(){
        return this.baseservice.getData("http://localhost:59010/api/GetAllDocuments",{});
    }

    constructor(public baseservice: BaseService) {

    }
    ngOnDestroy(){}
}
