import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientsTableComponent } from './components/clients-table/clients-table.component';
import { MaterialModule } from '../ui/modules/material.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { GetMatPaginatorIntl } from '../ui/consts/mat-table-translator.const';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ClientViewerComponent } from './components/client-viewer/client-viewer.component';
import { ClientCreatorComponent } from './components/client-creator/client-creator.component';
import { NgxSkeletonLoaderModule } from 'ngx-skeleton-loader';

@NgModule({
  declarations: [ClientsTableComponent,ClientViewerComponent, ClientCreatorComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    FontAwesomeModule,
    NgxSkeletonLoaderModule
  ],
  providers: [ { provide: MatPaginatorIntl, useValue: GetMatPaginatorIntl() } ],
  exports: [ClientsTableComponent]
})
export class ClientModule { }
