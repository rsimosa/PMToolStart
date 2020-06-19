import { Injectable } from '@angular/core';
import { Project } from '../dtos/Project';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ProjectListItem } from '../dtos/ProjectListItem';

@Injectable({
  providedIn: 'root'
})
export class PlanningService {

  constructor(private httpClient: HttpClient) { }

  public async newProject(): Promise<Project> {
    const promise = new Promise<Project>((resolve, reject) => {
      resolve({
        id: 0,
        name: '',
        start: new Date(),
        activities: [{
          id: 0,
          taskName: '',
          start: new Date(),
          finish: new Date(),
          estimate: 1.0,
          predecessors: "1",
          resource: '',
          priority: 500,
        }]
      });
    });
    return promise;
  }

  public async saveProject(project: Project): Promise<Project> {
    // note: the data might not match with server.
    return this.httpClient.post<Project>(
      'https://localhost:44349/Planning/SaveProject', project).toPromise();
  }

  public async projects(): Promise<ProjectListItem[]> {
    return this.httpClient.get<ProjectListItem[]>(
      'https://localhost:44349/Planning/Projects').toPromise();
  }

  public async project(id: number): Promise<Project> {
    //alert('project id: ' + projectId.toString());
    let params = new HttpParams().set('id',id.toString());
    return this.httpClient.get<Project>(
      `https://localhost:44349/Planning/Project?id=${id}`).toPromise();
  }
}
