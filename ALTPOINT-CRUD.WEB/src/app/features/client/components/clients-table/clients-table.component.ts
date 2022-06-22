import { Component, OnInit, ViewChild } from '@angular/core';
import { GetPaginationDto } from 'src/app/features/paginator/dtos/get-pagination.dto';
import { Pagination } from 'src/app/features/paginator/models/pagination.model';
import { Client } from '../../models/client.model';
import { ClientService } from '../../services/client.service';
import { faUserPlus } from '@fortawesome/free-solid-svg-icons';
import { PageEvent } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { ClientViewerComponent } from '../client-viewer/client-viewer.component';
import { ClientCreatorComponent } from '../client-creator/client-creator.component';
import { ClientEvents } from '../../events/client.events';
import { tap } from "rxjs";
import { OPACITY_ANIMATION } from 'src/app/features/ui/triggers/opacity-animation.trigger';
import { MatSort, Sort } from '@angular/material/sort';
import { SortDirectionType } from 'src/app/features/paginator/enums/sort-direction-type.enum';

@Component({
  selector: 'app-clients-table',
  templateUrl: './clients-table.component.html',
  styleUrls: ['./clients-table.component.scss'],
  animations: [OPACITY_ANIMATION]
})
export class ClientsTableComponent implements OnInit {

  @ViewChild(MatSort) sort: MatSort | null = null;
  clientPaginationRequest = {
    page: 1,
    limit: 5
  } as GetPaginationDto;
  clientPagination:Pagination<Client> | null = null;
  clientTableColumns:string[] = ['name', 'surname', 'patronymic'];
  faUserPlus = faUserPlus;
  
  constructor(
    private clientService:ClientService,
    private dialog:MatDialog,
    private clientEvents:ClientEvents) { }

  ngOnInit(): void {
    this.getPagination();
    this.clientEvents.updated$
    .pipe(tap(() => { this.getPagination() }))
    .subscribe();

    this.clientEvents.created$
    .pipe(tap(() => { this.getPagination() }))
    .subscribe();
  }

  getPagination()
  {
    this.clientService.getPagination(this.clientPaginationRequest)
      .subscribe(result => {this.clientPagination = result; });
  }

  paginatorChanged(event:PageEvent)
  {
    this.clientPaginationRequest.page = event.pageIndex + 1;
    this.clientPaginationRequest.limit = event.pageSize;
    this.getPagination();
  }

  clientPaginationRequestChanged()
  {
    this.getPagination();
  }

  openClientCreatorDialog()
  {
    this.dialog.open(ClientCreatorComponent);
  }

  openClientViewerDialog(client:Client)
  {
    this.dialog.open(ClientViewerComponent, { data: client })
  }

  sortChanged(sortState:Sort)
  {
    if (sortState.active && sortState.direction)
    {
      this.clientPaginationRequest.sortBy = sortState.active;
      this.clientPaginationRequest.sortDir = sortState.direction == 'asc' ? SortDirectionType.Asc : SortDirectionType.Desc;
    }
    else
    {
      this.clientPaginationRequest.sortBy = '';
      this.clientPaginationRequest.sortDir = SortDirectionType.Asc;
    } 
    this.getPagination();
  }
}
