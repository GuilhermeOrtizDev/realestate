import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { faAngleDoubleLeft, faAngleDoubleRight  } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit, OnChanges {
  public faAngleDoubleLeft = faAngleDoubleLeft; 
  public faAngleDoubleRight = faAngleDoubleRight; 

  @Input() public amount: number = 0;
  public page: number = 1;
  public pages: Array<number> = [];


  constructor(
    private _router: Router,
    private _route: ActivatedRoute) { }

  ngOnInit(): void {
    this._router.events.subscribe((event) => {
      if (event instanceof NavigationEnd){
        this.Get();
      }
    });
  }

  ngOnChanges(): void{
    this.Get();
  }

  private Get(){
    this.page = parseInt(this._route.snapshot.paramMap.get('page') ?? "1");
    
    if(this.page > this.amount)
      this.amount = 0;
    
    if(this.amount == 0)
      return;

    if(this.amount == 1)
      this.pages = [1];
    
    else if(this.amount == 2)
      this.pages = [1, 2];

    else if(this.page == 1)
    this.pages = [1, 2, 3];

    else if(this.page == this.amount)
      this.pages = [this.page - 2, this.page - 1, this.page];

    else if(this.page < this.amount)
      this.pages = [this.page - 1, this.page, this.page + 1];
  }

  public Pagination(redirect: any){
    var path = this._route.routeConfig?.path?.split("/");
    var params = window.location.href.split("?")[1];
    var indexPage = path?.indexOf(":page");
    var urlArray = this._route.snapshot.url.map(({path}) => path);
    
    if(indexPage != undefined && indexPage != -1)
      urlArray[indexPage] = `${redirect}`;
    else urlArray.push(`${redirect}`);

    var url = `${urlArray.join("/")}`; 

    if(params != undefined)
     url += `?${params}`;
    
    this._router.navigateByUrl(`${url}`);
  }

}
