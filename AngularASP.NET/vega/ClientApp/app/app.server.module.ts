import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';

@NgModule({
    bootstrap: [ AppComponent],
    imports: [
        ServerModule,
        AppModuleShared
    ]
})
export class AppModule {
}
