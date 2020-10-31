import { Injectable, OnDestroy } from '@angular/core';

@Injectable({providedIn: 'root'})
export class ConfigService implements OnDestroy {
    config
    manageData: any[] = [];
    saveConfig(config){
        this.config = config;
    }
    getConfig(){
        return this.config;
    }
    setManageData(data){
        let newData: any = {}
        debugger
        if(data && Object.keys(data) && Object.keys(data).length > 0 && data.config) {
            Object.keys(data.config).forEach((key: any)=> {
                newData[data.config[key]] = data.data[key];
            })

        }
        this.manageData.push(newData);
    }
    getManageData(){
        return this.manageData;
    }
    constructor(){}
    ngOnDestroy(){}
}