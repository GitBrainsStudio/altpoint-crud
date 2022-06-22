import { MatPaginatorIntl } from '@angular/material/paginator';


const MAT_TABLE_TRANSLATOR = (page: number, pageSize: number, length: number) => {
  if (length == 0 || pageSize == 0) { return `0 из ${length}`; }
  
  length = Math.max(length, 0);

  const startIndex = page * pageSize;

  // If the start index exceeds the list length, do not try and fix the end index to the end.
  const endIndex = startIndex < length ?
      Math.min(startIndex + pageSize, length) :
      startIndex + pageSize;

  return `${startIndex + 1} - ${endIndex} из ${length}`;
}


export function GetMatPaginatorIntl() {
  const paginatorIntl = new MatPaginatorIntl();
  
  paginatorIntl.itemsPerPageLabel = 'Кол-во элементов:';
  paginatorIntl.nextPageLabel = 'Далее';
  paginatorIntl.previousPageLabel = 'Назад';
  paginatorIntl.lastPageLabel = 'Крайняя страница';
  paginatorIntl.firstPageLabel = 'Первая страница';
  paginatorIntl.getRangeLabel = MAT_TABLE_TRANSLATOR;
  
  return paginatorIntl;
}
