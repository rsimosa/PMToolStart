import { Injectable } from '@angular/core';
import { identifierModuleUrl } from '@angular/compiler';
import { Project } from '../dtos/Project';


@Injectable({
  providedIn: 'root'
})

export class PlanningService {

  constructor() { }

  public async getProject(): Promise<Project> {
    const promise = new Promise<Project>((resolve, reject) => {
      resolve({
        id: 1,
        startDate: new Date(),
        activities: [
          {
            id: 1,
            taskName: 'Setup DB',
            start: new Date(),
            finish: new Date(),
            estimate: 1.0,
            predecessor: 1,
            resource: 'Doug',
            priority: 500
          }
        ]
      });
    });

    return promise;
  }

  public async newProject(): Promise<Project> {
    const promise = new Promise<Project>((resolve, reject) => {
      resolve({
        id: 1,
        startDate: new Date(),
        activities: [
          {
            id: 1,
            taskName: 'Setup DB',
            start: new Date(),
            finish: new Date(),
            estimate: 1.0,
            predecessor: 1,
            resource: 'Doug',
            priority: 500
          }
        ]
      });
    });

    return promise;
  }

  public async saveProject(ProjectObject: Project): Promise<void> {
    console.log(ProjectObject);
  }
}
